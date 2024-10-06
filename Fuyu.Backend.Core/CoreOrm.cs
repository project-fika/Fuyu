using System;
using System.Collections.Generic;
using Fuyu.Backend.Core.DTO.Accounts;

namespace Fuyu.Backend.Core
{
    public static class CoreOrm
    {
#region Accounts
        public static List<Account> GetAccounts()
        {
            return CoreDatabase.Accounts.ToList();
        }

        public static Account GetAccount(string sessionId)
        {
            var accountId = GetSession(sessionId);
            if (!CoreDatabase.Accounts.TryGet(accountId, out var account))
            {
                throw new Exception($"Failed to get account with sessionID: {sessionId}");
            }

            return account;
        }

        public static Account GetAccount(int accountId)
        {
            foreach (var entry in CoreDatabase.Accounts.ToList())
            {
                if (entry.Id == accountId)
                {
                    return entry;
                }
            }

            throw new Exception($"Account with {accountId} does not exist.");
        }

        public static void SetOrAddAccount(Account account)
        {
            var accounts = CoreDatabase.Accounts.ToList();

            for (var i = 0; i < accounts.Count; ++i)
            {
                if (accounts[i].Id == account.Id)
                {
                    CoreDatabase.Accounts.TrySet(i, account);
                    return;
                }
            }

            CoreDatabase.Accounts.Add(account);
        }

        public static void RemoveAccount(int accountId)
        {
            var accounts = CoreDatabase.Accounts.ToList();

            for (var i = 0; i < accounts.Count; ++i)
            {
                if (accounts[i].Id == accountId)
                {
                    CoreDatabase.Accounts.TryRemoveAt(i);
                    return;
                }
            }
        }
#endregion

#region Sessions
        public static Dictionary<string, int> GetSessions()
        {
            return CoreDatabase.Sessions.ToDictionary();
        }

        public static int GetSession(string sessionId)
        {
            if (!CoreDatabase.Sessions.TryGet(sessionId, out var id))
            {
                throw new Exception($"Failed to find ID for sessionId: {sessionId}");
            }

            return id;
        }

        public static void SetOrAddSession(string sessionId, int accountId)
        {
            if (CoreDatabase.Sessions.ContainsKey(sessionId))
            {
                CoreDatabase.Sessions.Set(sessionId, accountId);
            }
            else
            {
                CoreDatabase.Sessions.Set(sessionId, accountId);
            }
        }

        public static void RemoveSession(string sessionId)
        {
            CoreDatabase.Sessions.Remove(sessionId);
        }
#endregion
    }
}