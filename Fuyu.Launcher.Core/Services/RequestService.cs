using System.Text;
using Fuyu.Common.Collections;
using Fuyu.Common.Hashing;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;
using Fuyu.Backend.Common.DTO.Requests;
using Fuyu.Backend.Common.DTO.Responses;
using Fuyu.Backend.Core.DTO.Accounts;
using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.DTO.Responses;

namespace Fuyu.Launcher.Core.Services
{
    public static class RequestService
    {
        private static ThreadDictionary<string, HttpClient> _httpClients;

        static RequestService()
        {
            _httpClients = new ThreadDictionary<string, HttpClient>();

            _httpClients.Add("fuyu", new HttpClient(SettingsService.FuyuAddress, string.Empty));
            _httpClients.Add("eft", new HttpClient(SettingsService.EftAddress, string.Empty));
            _httpClients.Add("arena", new HttpClient(SettingsService.ArenaAddress, string.Empty));
        }

        private static T2 HttpPost<T1, T2>(string id, string path, T1 request)
        {
            var httpc = _httpClients.Get(id);

            var requestJson = Json.Stringify(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);

            var responseBytes = httpc.Post(path, requestBytes);
            var responseJson = Encoding.UTF8.GetString(responseBytes);
            var response = Json.Parse<T2>(responseJson);

            return response;
        }

        public static void CreateSession(string id, string address, string sessionId)
        {
            _httpClients.Set(id, new HttpClient(address, sessionId));
        }

        public static ERegisterStatus RegisterAccount(string username, string password)
        {
            var request = new AccountRegisterRequest()
            {
                Username = username,
                Password = password
            };
            var response = HttpPost<AccountRegisterRequest, AccountRegisterResponse>(
                "fuyu",
                "/account/register",
                request);

            return response.Status;
        }

        public static string LoginAccount(string username, string password)
        {
            var hashedPassword = Sha256.Generate(password);
            var request = new AccountLoginRequest()
            {
                Username = username,
                Password = hashedPassword
            };
            var response = HttpPost<AccountLoginRequest, AccountLoginResponse>(
                "fuyu",
                "/account/login",
                request);

            return response.SessionId;
        }

        public static ERegisterStatus RegisterGame(string game, string edition)
        {
            var request = new AccountRegisterGameRequest()
            {
                Game = game,
                Edition = edition
            };
            var response = HttpPost<AccountRegisterGameRequest, AccountRegisterGameResponse>(
                "fuyu",
                "/account/register/game",
                request);

            return response.Status;
        }

        public static string LoginGame(string game, int accountId)
        {
            var request = new FuyuGameLoginRequest()
            {
                AccountId = accountId
            };
            var response = HttpPost<FuyuGameLoginRequest, FuyuGameLoginResponse>(
                game,
                "/fuyu/game/login",
                request);

            return response.SessionId;
        }
    }
}
