using System;
using System.Collections.Generic;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.Fuyu.Accounts;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Databases.Fuyu
{
    public class AccountTable
    {
        static AccountTable()
        {
            _accountsLock = new object();
            _sessionsLock = new object();
            _pathLock = new object();
        }

        public AccountTable()
        {
            _path = "./fuyu/accounts/";
            _accounts = [];
            _sessions = [];
        }

        public void Load()
        {
            LoadAccounts();
            LoadSessions();
        }

#region path
        // TODO:
        // * move to a config system
        // -- seionmoya, 2024/09/02
        private string _path;
        private static readonly object _pathLock;

        public string GetPath()
        {
            return _path;
        }

        public void SetPath(string path)
        {
            lock (_pathLock)
            {
                _path = path;
            }
        }
#endregion

#region Accounts
        // NOTE: rationale for using List<Account> over Dictionary<int, Account>
        //       is the accountId is already stored in the Account so having to
        //       sync both the Account.Id and dictionary is a bit annoying, and 
        //       a dictionary loops over all keys anyways (unless using
        //       TryGetValue() but that uses 'out' which I want to avoid).
        // -- seionmoya, 2024/09/02

        private readonly List<Account> _accounts;
        private static readonly object _accountsLock;

        // TODO:
        // * separate database from loading functionality
        // -- seionmoya, 2024/09/02
        private void LoadAccounts()
        {
            if (!VFS.DirectoryExists(_path))
            {
                VFS.CreateDirectory(_path);
            }

            var files = VFS.GetFiles(_path);

            foreach (var filepath in files)
            {
                var json = VFS.ReadTextFile(filepath);
                var account = Json.Parse<Account>(json);
                AddAccount(account);

                Terminal.WriteLine($"Loaded account {account.Id}");
            }
        }

        public List<Account> GetAccounts()
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
            foreach (var entry in _accounts)
            {
                if (entry.Id == accountId)
                {
                    return entry;
                }
            }

            throw new Exception($"Account with {accountId} does not exist.");
        }

        public void SetAccount(int accountId, Account account)
        {
            for (var i = 0; i < _accounts.Count; ++i)
            {
                if (_accounts[i].Id == accountId)
                {
                    lock (_accountsLock)
                    {
                        _accounts[i] = account;
                    }

                    return;
                }
            }

            throw new Exception($"Account with {accountId} does not exist.");
        }

        public void AddAccount(Account account)
        {
            foreach (var entry in _accounts)
            {
                if (entry.Id == account.Id)
                {
                    _accounts.Remove(entry);
                }
            }

            lock (_accountsLock)
            {
                _accounts.Add(account);
            }
        }

        public void RemoveAccount(int accountId)
        {
            foreach (var entry in _accounts)
            {
                if (entry.Id == accountId)
                {
                    lock (_accountsLock)
                    {
                        _accounts.Remove(entry);
                    }

                    return;
                }
            }

            throw new Exception($"Account with {accountId} does not exist.");
        }
#endregion

#region Sessions
//                                  sessid  aid
        private readonly Dictionary<string, int> _sessions;
        private static readonly object _sessionsLock;

        public void LoadSessions()
        {
            // intentionally empty
            // sessions are created when users are logged in successfully
            // -- seionmoya, 2024/09/02
        }

        public int GetSession(string sessionId)
        {
            if (!_sessions.ContainsKey(sessionId))
            {
                throw new Exception($"Session {sessionId} does not exist.");
            }

            return _sessions[sessionId];
        }

        public void SetSession(string sessionId, int accountId)
        {
            if (!_sessions.ContainsKey(sessionId))
            {
                throw new Exception($"Session {sessionId} does not exist.");
            }

            lock (_sessionsLock)
            {
                _sessions[sessionId] = accountId;
            }
        }

        public void AddSession(string sessionId, int accountId)
        {
            if (_sessions.ContainsKey(sessionId))
            {
                lock (_sessionsLock)
                {
                    _sessions[sessionId] = accountId;
                }
            }
            else
            {
                lock (_sessionsLock)
                {
                    _sessions.Add(sessionId, accountId);
                }
            }
        }

        public void RemoveSession(string sessionId)
        {
            if (!_sessions.ContainsKey(sessionId))
            {
                throw new Exception($"Session {sessionId} does not exist.");
            }

            lock (_sessionsLock)
            {
                _sessions.Remove(sessionId);
            }
        }
#endregion
    }
}