using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Wealth.Models;

namespace Wealth.Data.Client
{
    public class WealthDataClient
    {
        private static readonly IDictionary<ulong, Account> __accounts;
        private static readonly IDictionary<ulong, AccountUser> __accountUsers;

        static void AddAccount(Account account)
        {
            __accounts.Add(account.Id, account);
        }

        static void AddAccountUser(AccountUser accountUser)
        {
            __accountUsers.Add(accountUser.Id, accountUser);
        }

        static WealthDataClient()
        {
            __accounts = new ConcurrentDictionary<ulong, Account>();
            __accountUsers = new ConcurrentDictionary<ulong, AccountUser>();

            AddAccount(new Account { Id = 1001, AccountName = "John", IsActive = true, CreationDate = DateTimeOffset.UtcNow });
            AddAccount(new Account { Id = 1002, AccountName = "Peter", IsActive = true, CreationDate = DateTimeOffset.UtcNow });

            AddAccountUser(new AccountUser { AccountId = 1001, Id = 7001, FirstName = "John", LastName = "Green", LoginName = "john-green", IsActive = true, CreationDate = DateTimeOffset.UtcNow });
            AddAccountUser(new AccountUser { AccountId = 1002, Id = 6001, FirstName = "Peter 1", LastName = "Hood", LoginName = "peter1", IsActive = true, CreationDate = DateTimeOffset.UtcNow });
            AddAccountUser(new AccountUser { AccountId = 1002, Id = 6002, FirstName = "Peter 2", LastName = "Hood", LoginName = "peter2", IsActive = true, CreationDate = DateTimeOffset.UtcNow });
        }

        public WealthDataClient()
        {
        }

        public async Task<Account> GetAccount(string loginName, ulong partnerId)
        {
            var accountUser = await GetAccountUser(loginName, partnerId);
            if (accountUser != null)
            {
                _ = __accounts.TryGetValue(accountUser.AccountId, out var account);
                return await Task.FromResult(account);
            }
            return null;
        }

        public async Task<IEnumerable<Account>> GetAccountList()
        {
            return await Task.FromResult(__accounts.Values);
        }

        public async Task<Account> GetAccount(ulong id)
        {
            _ = __accounts.TryGetValue(id, out var account);
            return await Task.FromResult(account);
        }

        public async Task CreateAccount(Account account)
        {
            account.Id = (ulong)DateTimeOffset.UtcNow.Ticks;
            AddAccount(account);
            await Task.CompletedTask;
        }

        public async Task UpdateAccount(Account account)
        {
            var accountOld = await GetAccount(account.Id);
            if (accountOld != null)
            {
                accountOld.AccountName = account.AccountName;
                accountOld.ModificationDate = DateTimeOffset.UtcNow;
            }
        }

        public async Task DeleteAccount(ulong id)
        {
            __accounts.Remove(id);
            await Task.CompletedTask;
        }

        public async Task<AccountUser> GetAccountUser(string loginName, ulong partnerId)
        {
            var accountUser = __accountUsers.Values.Where(u => u.LoginName == loginName && u.PartnerId == partnerId).SingleOrDefault();
            return await Task.FromResult(accountUser);
        }

        public async Task<IEnumerable<AccountUser>> GetAccountUserListForAccount(ulong accountId)
        {
            return await Task.FromResult(__accountUsers.Values.Where(u => u.AccountId == accountId));
        }

        public async Task<IEnumerable<AccountUser>> GetAccountUserList()
        {
            return await Task.FromResult(__accountUsers.Values);
        }

        public async Task<AccountUser> GetAccountUser(ulong id)
        {
            _ = __accountUsers.TryGetValue(id, out var accountUser);
            return await Task.FromResult(accountUser);
        }

        public async Task CreateAccountUser(AccountUser accountUser)
        {
            accountUser.Id = (ulong)DateTimeOffset.UtcNow.Ticks;
            AddAccountUser(accountUser);
            await Task.CompletedTask;
        }

        public async Task UpdateAccountUser(AccountUser accountUser)
        {
            var accountUserOld = await GetAccountUser(accountUser.Id);
            if (accountUserOld != null)
            {
                accountUserOld.FirstName = accountUser.FirstName;
                accountUserOld.LastName = accountUser.LastName;
                accountUserOld.ModificationDate = DateTimeOffset.UtcNow;
            }
        }

        public async Task DeleteAccountUser(ulong id)
        {
            __accountUsers.Remove(id);
            await Task.CompletedTask;
        }
    }
}
