using System.Text;
using Fuyu.Common.Collections;
using Fuyu.Backend.Common.DTO.Requests;
using Fuyu.Backend.Common.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Backend.Core.Services
{
    public static class RequestService
    {
        private static ThreadDictionary<string, HttpClient> _httpClients;

        static RequestService()
        {
            _httpClients = new ThreadDictionary<string, HttpClient>();

            // TODO:
            // * get address from config
            // -- seionmoya, 2024/09/08
            _httpClients.Add("fuyu", new EftHttpClient("http://localhost:8000", string.Empty));
            _httpClients.Add("eft", new EftHttpClient("http://localhost:8010", string.Empty));
            _httpClients.Add("arena", new EftHttpClient("http://localhost:8020", string.Empty));
        }

        private static T2 HttpPost<T1, T2>(string id, string path, T1 request)
        {
            var httpc = _httpClients.Get(id);

            var requestJson = Json.Stringify(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);

            var response = httpc.Post(path, requestBytes);
            var responseJson = Encoding.UTF8.GetString(response.Body);
            var responseValue = Json.Parse<T2>(responseJson);

            return responseValue;
        }

        public static void CreateSession(string id, string address, string sessionId)
        {
            _httpClients.Set(id, new EftHttpClient(address, sessionId));
        }

        public static int RegisterGame(string game, string username, string edition)
        {
            var request = new FuyuGameRegisterRequest()
                {
                    Username = username,
                    Edition = edition
                };
            var response = HttpPost<FuyuGameRegisterRequest, FuyuGameRegisterResponse>(
                game,
                "/fuyu/game/register",
                request);

            return response.AccountId;
        }
    }
}
