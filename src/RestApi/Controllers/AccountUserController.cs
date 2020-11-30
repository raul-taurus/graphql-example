using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Wealth.Data.Client;
using Wealth.Models;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountUserController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly WealthDataClient _dataClient;

        public AccountUserController(ILogger<AccountUserController> logger, WealthDataClient dataClient)
        {
            _logger = logger;
            _dataClient = dataClient;
        }

        [HttpGet("{id}")]
        public async Task<AccountUser> Get(ulong id)
        {
            return await _dataClient.GetAccountUser(id);
        }

        [HttpGet("list")]
        public async Task<IEnumerable<AccountUser>> GetList()
        {
            return await _dataClient.GetAccountUserList();
        }

        [HttpPut]
        public async Task Update(AccountUser account)
        {
            await _dataClient.UpdateAccountUser(account);
        }
    }
}
