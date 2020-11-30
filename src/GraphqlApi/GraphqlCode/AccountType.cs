using GraphQL;
using GraphQL.Types;
using Wealth.Data.Client;
using Wealth.Models;

namespace GraphqlApi
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType(WealthDataClient data)
        {
            Name = "Account";

            Field(h => h.Id).Description("The id of the account.");
            Field(h => h.AccountName, nullable: true).Description("The name of the account.");

            Field<ListGraphType<AccountUserType>>("users",
                resolve: context => data.GetAccountUserListForAccount(context.Source.Id)
            );
        }
    }
}
