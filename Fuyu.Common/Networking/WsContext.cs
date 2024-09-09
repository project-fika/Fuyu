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
    public delegate void OnCloseCallback(WsContext context);
    public delegate void OnTextCallback(WsContext context, string text);
    public delegate void OnBinaryCallback(WsContext context, byte[] data);

    public class WsContext : Context
    {
        private const int _bufferSize = 32000;
        private readonly WebSocket _ws;
        public OnCloseCallback OnClose;
        public OnTextCallback OnText;
        public OnBinaryCallback OnData;

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
            var receiveBuffer = new byte[_bufferSize];
            var receiveResult = await _ws.ReceiveAsync(new ArraySegment<byte>(receiveBuffer), CancellationToken.None);

            switch (receiveResult.MessageType)
            {
                case WebSocketMessageType.Close:
                    OnClose(this);
                    await CloseAsync();
                    break;

                case WebSocketMessageType.Text:
                    var text = Encoding.UTF8.GetString(receiveBuffer);
                    OnText(this, text);
                    break;

                case WebSocketMessageType.Binary:
                    var data = new byte[receiveResult.Count];
                    Array.Copy(receiveBuffer, 0, data, 0, data.Length);
                    OnData(this, data);
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