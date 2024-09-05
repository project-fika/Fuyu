using System.Text;
using Fuyu.Common.Collections;
using Fuyu.Backend.Core.DTO.Accounts;
using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.DTO.Responses;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Launcher.Core.Services
{
    public static class RequestService
    {
        private static ThreadObject<HttpClient> _httpClient;

        static RequestService()
        {
            CreateSession(string.Empty);
        }

        private static T2 HttpPost<T1, T2>(string path, T1 request)
        {
            var httpc = _httpClient.Get();

            var requestJson = Json.Stringify(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);

            var responseBytes = httpc.Post(path, requestBytes);
            var responseJson = Encoding.UTF8.GetString(responseBytes);
            var response = Json.Parse<T2>(responseJson);

            return response;
        }

        public static void CreateSession(string sessionId)
        {
            var httpc = new HttpClient(SettingsService.FuyuAddress, sessionId);
            _httpClient = new ThreadObject<HttpClient>(httpc);
        }

        public static ERegisterStatus RegisterAccount(string username, string password)
        {
            var request = new AccountRegisterRequest()
            {
                Username = username,
                Password = password
            };
            var response = HttpPost<AccountRegisterRequest, AccountRegisterResponse>("/account/register", request);

            return response.Status;
        }

        public static string LoginAccount(string username, string password)
        {
            var request = new AccountLoginRequest()
            {
                Username = username,
                Password = password
            };
            var response = HttpPost<AccountLoginRequest, AccountLoginResponse>("/account/login", request);

            return response.SessionId;
        }

        public static ERegisterStatus RegisterGame(EGame game, string edition)
        {
            var request = new AccountRegisterGameRequest()
            {
                Game = game,
                Edition = edition
            };
            var response = HttpPost<AccountRegisterGameRequest, AccountRegisterGameResponse>("/account/register/game", request);

            return response.Status;
        }
    }
}
