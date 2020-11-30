using GraphQL.Types;
using Wealth.Data.Client;
using Wealth.Models;

namespace GraphqlApi
{
    public class AccountUserType : ObjectGraphType<AccountUser>
    {
        public AccountUserType(WealthDataClient data)
        {
            Name = "AccountUser";
            Field(h => h.Id).Description("The id of the user.");
            Field(h => h.FirstName, nullable: true).Description("The first name of the user.");
            Field(h => h.LastName, nullable: true).Description("The last name of the user.");
        }
    }
}
