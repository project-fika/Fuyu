using System;
using System.Collections.Generic;
using Fuyu.Platform.Common.Collections;
using Fuyu.Platform.Common.IO;
using Fuyu.Platform.Common.Models.Fuyu.Accounts;
using Fuyu.Platform.Common.Serialization;

namespace Fuyu.Platform.Server.Databases.Fuyu
{
    public class AccountTable
    {
        public AccountTable()
        {
            _path = new ThreadObject<string>(string.Empty);
            _accounts = new ThreadList<Account>();
            _sessions = new ThreadDictionary<string, int>();
        }

        public void Load()
        {
            LoadPath();
            LoadAccounts();
            LoadSessions();
        }

#region path
        // TODO:
        // * move to a config system
        // -- seionmoya, 2024/09/02
        private readonly ThreadObject<string> _path;

        public void LoadPath()
        {
            SetPath("./fuyu/accounts/");
        }

        public string GetPath()
        {
            return _path.Get();
        }

        public void SetPath(string path)
        {
            _path.Set(path);
        }
#endregion

#region Accounts
        // NOTE: rationale for using List<Account> over Dictionary<int, Account>
        //       is the accountId is already stored in the Account so having to
        //       sync both the Account.Id and dictionary is a bit annoying, and 
        //       a dictionary loops over all keys anyways (unless using
        //       TryGetValue() but that uses 'out' which I want to avoid).
        // -- seionmoya, 2024/09/02

        private readonly ThreadList<Account> _accounts;

        // TODO:
        // * separate database from loading functionality
        // -- seionmoya, 2024/09/02
        private void LoadAccounts()
        {
            var path = _path.Get();

            if (!VFS.DirectoryExists(path))
            {
                VFS.CreateDirectory(path);
            }

            var files = VFS.GetFiles(path);

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
            return _accounts.ToList();
        }

        public Account GetAccount(string sessionId)
        {
            var accountId = GetSession(sessionId);
            return _accounts.Get(accountId);
        }

        public Account GetAccount(int accountId)
        {
            foreach (var entry in _accounts.ToList())
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
            var accounts = _accounts.ToList();

            for (var i = 0; i < accounts.Count; ++i)
            {
                if (accounts[i].Id == accountId)
                {
                    _accounts.Set(i, account);
                    return;
                }
            }
        }

        public void AddAccount(Account account)
        {
            var accounts = _accounts.ToList();

            for (var i = 0; i < accounts.Count; ++i)
            {
                if (accounts[i].Id == account.Id)
                {
                    _accounts.RemoveAt(i);
                    break;
                }
            }

            _accounts.Add(account);
        }

        public void RemoveAccount(int accountId)
        {
            foreach (var entry in _accounts.ToList())
            {
                if (entry.Id == accountId)
                {
                    _accounts.Remove(entry);
                    return;
                }
            }

            throw new Exception($"Account with {accountId} does not exist.");
        }
#endregion

#region Sessions
//                                        sessid  aid
        private readonly ThreadDictionary<string, int> _sessions;

        public void LoadSessions()
        {
            // intentionally empty
            // sessions are created when users are logged in successfully
            // -- seionmoya, 2024/09/02
        }

        public Dictionary<string, int> GetSessions()
        {
            return _sessions.ToDictionary();
        }

        public int GetSession(string sessionId)
        {
            return _sessions.Get(sessionId);
        }

        public void SetSession(string sessionId, int accountId)
        {
            _sessions.Set(sessionId, accountId);
        }

        public void AddSession(string sessionId, int accountId)
        {
            _sessions.Add(sessionId, accountId);
        }

        public void RemoveSession(string sessionId)
        {
            _sessions.Remove(sessionId);
        }
#endregion
    }
}