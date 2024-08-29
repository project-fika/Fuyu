using System.Collections.Generic;
using Fuyu.Platform.Common.Models.Fuyu;
using Fuyu.Platform.Common.Models.Fuyu.Savegame;

namespace Fuyu.Platform.Server.Databases.Fuyu
{
    public class AccountTable
    {
        static AccountTable()
        {
            _accountsLock = new object();
            _sessionsLock = new object();
        }

        public AccountTable()
        {
            _accounts = new Dictionary<int, Account>();
            _sessions = new Dictionary<string, int>();
        }

        public void Load()
        {
            LoadAccounts();
            LoadSessions();
        }

#region Accounts
//                                  aid  account
        private readonly Dictionary<int, Account> _accounts;
        private static readonly object _accountsLock;

        private void LoadAccounts()
        {
            var account = new Account()
            {
                Username = "Senko-san",
                Password = string.Empty,
                EftSave = new EftSave()
                {
                    Edition = "Unheard",
                    PvE = new EftProfile()
                    {
                        Savage = default,
                        Pmc = default,
                        Suites = [],
                        ShouldWipe = true
                    },
                    PvP = new EftProfile()
                    {
                        Savage = default,
                        Pmc = default,
                        Suites = [],
                        ShouldWipe = true
                    }
                }
            };

            AddAccount(1, account);
        }

        public Dictionary<int, Account> GetAccounts()
        {
            return _accounts;
        }

        public Account GetAccount(string sessionId)
        {
            var accountId = GetSession(sessionId);
            return _accounts[accountId];
        }

        public Account GetAccount(int accountId)
        {
            return _accounts[accountId];
        }

        public void SetAccount(int accountId, Account account)
        {
            lock (_accountsLock)
            {
                _accounts[accountId] = account;
            }
        }

        public void AddAccount(int accountId, Account account)
        {
            lock (_accountsLock)
            {
                _accounts.Add(accountId, account);
            }
        }

        public void RemoveAccount(int accountId)
        {
            lock (_accountsLock)
            {
                _accounts.Remove(accountId);
            }
        }
#endregion

#region Sessions
//                                  sessid  aid
        private readonly Dictionary<string, int> _sessions;
        private static readonly object _sessionsLock;

        public void LoadSessions()
        {
            AddSession("test", 1);
        }

        public int GetSession(string sessionId)
        {
            return _sessions[sessionId];
        }

        public void SetSession(string sessionId, int accountId)
        {
            lock (_sessionsLock)
            {
                _sessions[sessionId] = accountId;
            }
        }

        public void AddSession(string sessionId, int accountId)
        {
            lock (_sessionsLock)
            {
                _sessions.Add(sessionId, accountId);
            }
        }

        public void RemoveSession(string sessionId)
        {
            lock (_sessionsLock)
            {
                _sessions.Remove(sessionId);
            }
        }
#endregion
    }
}