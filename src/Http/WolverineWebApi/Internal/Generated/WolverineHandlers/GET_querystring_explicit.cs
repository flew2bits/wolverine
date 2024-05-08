// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: GET_querystring_explicit
    public class GET_querystring_explicit : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;

        public GET_querystring_explicit(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            string name = httpContext.Request.Query["name"].FirstOrDefault();
            
            // The actual HTTP request handler execution
            var result_of_UsingEnumQuerystring = WolverineWebApi.QuerystringEndpoints.UsingEnumQuerystring(name);

            await WriteString(httpContext, result_of_UsingEnumQuerystring);
        }
    }

    // END: GET_querystring_explicit
    
    
}