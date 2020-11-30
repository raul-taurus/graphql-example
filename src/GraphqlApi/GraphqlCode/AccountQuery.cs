using System;
using GraphQL;
using GraphQL.Types;
using Wealth.Data.Client;

namespace GraphqlApi
{
    public class AccountQuery : ObjectGraphType<object>
    {
        public AccountQuery(WealthDataClient data)
        {
            Name = "Query";

            Field<AccountType>("account",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ULongGraphType>> { Name = "id", Description = "id of the account" }
                ),
                resolve: context => data.GetAccount(context.GetArgument<ulong>("id"))
            );
        }
    }
}