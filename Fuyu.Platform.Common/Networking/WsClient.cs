using System;
using WebSocketSharp;

namespace Fuyu.Platform.Common.Networking
{
    public class WsClient : IDisposable
    {
        private readonly string _url;
        private WebSocket _ws;

        public WsClient(string address, string path)
        {
            _url = address + path;
        }

        public void Start()
        {
            _ws = new WebSocket(_url)
            {
                EmitOnPing = true
            };

            _ws.OnMessage += OnMessage;
            _ws.Connect();
        }

        public void Stop()
        {
            _ws.Close();
        }

        public void Send(string text)
        {
            _ws.Send(text);
        }

        public void Send(byte[] data)
        {
            _ws.Send(data);
        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            if (e.IsPing)
            {
                OnReceivePing();
            }

            if (e.IsText)
            {
                OnReceiveText(e.Data);
            }

            if (e.IsBinary)
            {
                OnReceiveBytes(e.RawData);
            }
        }

        public virtual void OnReceivePing()
        {
            // intentionally empty
        }

        public virtual void OnReceiveText(string text)
        {
            // intentionally empty
        }

        public virtual void OnReceiveBytes(byte[] data)
        {
            // intentionally empty
        }

        public void Dispose()
        {
            Stop();
        }
    }
}