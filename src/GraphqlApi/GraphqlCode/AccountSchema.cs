using System;
using GraphQL.Types;

namespace GraphqlApi
{
    public class AccountSchema : Schema
    {
        public AccountSchema(IServiceProvider provider, AccountQuery query)
            : base(provider)
        {
            Query = query;
        }
    }
}