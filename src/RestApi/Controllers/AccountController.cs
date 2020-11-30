using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Models;
using Wealth.Data.Client;
using Wealth.Models;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly WealthDataClient _dataClient;

        public AccountController(ILogger<AccountController> logger, WealthDataClient dataClient)
        {
            _logger = logger;
            _dataClient = dataClient;
        }

        [HttpGet("{id}")]
        public async Task<Account> Get(ulong id)
        {
            return await _dataClient.GetAccount(id);
        }

        [HttpGet("{id}/with-users")]
        public async Task<AccountWithUsers> GetWithUserList(ulong id)
        {
            var account = new AccountWithUsers();
            account.Account = await _dataClient.GetAccount(id);
            account.Users = await _dataClient.GetAccountUserListForAccount(account.Account.Id);

            return account;
        }

        [HttpGet("list")]
        public async Task<IEnumerable<Account>> GetList()
        {
            return await _dataClient.GetAccountList();
        }

        [HttpPut]
        public async Task Update(Account account)
        {
            await _dataClient.UpdateAccount(account);
        }
    }
}
