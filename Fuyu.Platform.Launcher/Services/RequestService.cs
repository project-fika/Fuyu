using System;
using System.Text;
using Fuyu.Platform.Common.Models.Fuyu.Requests;
using Fuyu.Platform.Common.Models.Fuyu.Responses;
using Fuyu.Platform.Common.Networking;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Launcher.Services
{
    public static class RequestService
    {
        private static readonly HttpClient _httpClient;

        static RequestService()
        {
            _httpClient = new HttpClient(SettingsService.FuyuAddress);
        }

        private static T2 HttpPost<T1, T2>(string path, T1 request)
        {
            var requestJson = Json.Stringify(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);
            var responseBytes = _httpClient.Post(path, requestBytes);
            var responseJson = Encoding.UTF8.GetString(responseBytes);
            var response = Json.Parse<T2>(responseJson);
            return response;
        }

        public static void RegisterAccount(string username, string password, string edition)
        {
            var request = new AccountRegisterRequest()
            {
                Username = username,
                Password = password,
                Edition = edition
            };
            var response = HttpPost<AccountRegisterRequest, AccountRegisterResponse>("/account/register", request);

            if (response.Status != ERegisterStatus.Success)
            {
                throw new Exception($"Could not register account {username}.");
            }
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
    }
}
