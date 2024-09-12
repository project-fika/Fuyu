using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fuyu.Common.Compression;
using Fuyu.Common.Serialization;

namespace Fuyu.Common.Networking
{
    public class WsContext : Context
    {
        private const int _bufferSize = 32000;
        private readonly WebSocket _ws;

        public Func<WsContext, Task> OnCloseAsync;
        public Func<WsContext, string, Task> OnTextAsync;
        public Func<WsContext, byte[], Task> OnBinaryAsync;

        public WsContext(HttpListenerRequest request, HttpListenerResponse response, WebSocket ws) : base(request, response)
        {
            _ws = ws;
        }

        public bool IsOpen()
        {
            return _ws.State == WebSocketState.Open;
        }

        // TODO:
        // * use System.Buffers.ArrayPool for receiveBuffer
        // -- seionmoya, 2024/09/09
        public async Task ReceiveAsync()
        {
            var buffer = new byte[_bufferSize];
            var received = await _ws.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            var data = new byte[received.Count];
            Array.Copy(buffer, 0, data, 0, data.Length);

            switch (received.MessageType)
            {
                case WebSocketMessageType.Close:
                    await OnCloseAsync(this);
                    await CloseAsync();
                    break;

                case WebSocketMessageType.Text:
                    var text = Encoding.UTF8.GetString(data);
                    await OnTextAsync(this, text);
                    break;

                case WebSocketMessageType.Binary:
                    await OnBinaryAsync(this, data);
                    break;
            }
        }

        public async Task SendTextAsync(string text)
        {
            var encoded = Encoding.UTF8.GetBytes(text);
            var buffer = new ArraySegment<byte>(encoded, 0, encoded.Length);
            await _ws.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task SendBinaryAsync(byte[] data)
        {
            var buffer = new ArraySegment<byte>(data, 0, data.Length);
            await _ws.SendAsync(buffer, WebSocketMessageType.Binary, true, CancellationToken.None);
        }

        public async Task CloseAsync()
        {
            await _ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
        }
    }
}