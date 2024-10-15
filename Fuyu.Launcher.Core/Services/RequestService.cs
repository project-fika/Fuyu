using System;
using System.Collections.Generic;
using System.Text;
using Fuyu.Backend.Common.DTO.Requests;
using Fuyu.Backend.Common.DTO.Responses;
using Fuyu.Backend.Core.DTO.Accounts;
using Fuyu.Backend.Core.DTO.Requests;
using Fuyu.Backend.Core.DTO.Responses;
using Fuyu.Common.Collections;
using Fuyu.Common.Hashing;
using Fuyu.Common.Networking;
using Fuyu.Common.Serialization;

namespace Fuyu.Launcher.Core.Services
{
    public static class RequestService
    {
        private static ThreadDictionary<string, HttpClient> _httpClients;

        static RequestService()
        {
            _httpClients = new ThreadDictionary<string, HttpClient>();

            _httpClients.Set("fuyu", new EftHttpClient(SettingsService.FuyuAddress, string.Empty));
            _httpClients.Set("eft", new EftHttpClient(SettingsService.EftAddress, string.Empty));
            _httpClients.Set("arena", new EftHttpClient(SettingsService.ArenaAddress, string.Empty));
        }

        private static TResponse HttpGet<TResponse>(string id, string path)
		{
			if (!_httpClients.TryGet(id, out var httpc))
			{
				throw new Exception($"Id '{id}' not found");
			}

            var response = httpc.Get(path);
            var responseJson = Encoding.UTF8.GetString(response.Body);
            var responseValue = Json.Parse<TResponse>(responseJson);

            return responseValue;
        }

        private static TResponse HttpPost<TRequest, TResponse>(string id, string path, TRequest request)
		{
			if (!_httpClients.TryGet(id, out var httpc))
			{
				throw new Exception($"Id '{id}' not found");
			}

			var requestJson = Json.Stringify(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);

            var response = httpc.Post(path, requestBytes);
            var responseJson = Encoding.UTF8.GetString(response.Body);
            var responseValue = Json.Parse<TResponse>(responseJson);

            return responseValue;
        }

        private static void HttpPut<TRequest>(string id, string path, TRequest request)
		{
			if (!_httpClients.TryGet(id, out var httpc))
			{
				throw new Exception($"Id '{id}' not found");
			}

			var requestJson = Json.Stringify(request);
            var requestBytes = Encoding.UTF8.GetBytes(requestJson);

            httpc.Put(path, requestBytes);
        }

        public static void ResetSessions()
        {
            _httpClients.Set("fuyu", new EftHttpClient(SettingsService.FuyuAddress, string.Empty));
            _httpClients.Set("eft", new EftHttpClient(SettingsService.EftAddress, string.Empty));
            _httpClients.Set("arena", new EftHttpClient(SettingsService.ArenaAddress, string.Empty));
        }

        public static void CreateSession(string id, string address, string sessionId)
        {
            _httpClients.Set(id, new EftHttpClient(address, sessionId));
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

        public static AccountLoginResponse LoginAccount(string username, string password)
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

            return response;
        }

        public static void LogoutAccount()
        {
            HttpPut<object>(
                "fuyu",
                "/account/logout",
                null);

            ResetSessions();
        }

        public static Dictionary<string, int?> GetGames()
        {
            var response = HttpPost<object, AccountGamesResponse>(
                "fuyu",
                "/account/games",
                null);

            return response.Games;
        }

        public static string[] GetWipeProfiles()
        {
            var response = HttpGet<string[]>(
                "eft",
                "/fuyu/game/wipe/profiles");
            
            return response;
        }

        public static AccountRegisterGameResponse RegisterGame(string game, string edition)
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

            return response;
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
