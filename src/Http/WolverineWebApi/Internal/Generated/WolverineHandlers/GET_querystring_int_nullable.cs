// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: GET_querystring_int_nullable
    public class GET_querystring_int_nullable : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;

        public GET_querystring_int_nullable(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            int? age = null;
            if (int.TryParse(httpContext.Request.Query["age"], System.Globalization.CultureInfo.InvariantCulture, out var ageParsed)) age = ageParsed;
            // Just saying hello in the code! Also testing the usage of attributes to customize endpoints
            
            // The actual HTTP request handler execution
            var result_of_UsingQueryStringParsingNullable = WolverineWebApi.TestEndpoints.UsingQueryStringParsingNullable(age);

            await WriteString(httpContext, result_of_UsingQueryStringParsingNullable);
        }
    }

    // END: GET_querystring_int_nullable
    
    
}