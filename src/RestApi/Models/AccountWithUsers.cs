using System.Collections.Generic;
using Wealth.Models;

namespace RestApi.Models
{
    public class AccountWithUsers
    {
        public Account Account { get; set; }
        public IEnumerable<AccountUser> Users { get; set; }
    }
}