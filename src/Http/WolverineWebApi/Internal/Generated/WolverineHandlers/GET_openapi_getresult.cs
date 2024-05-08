// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: GET_openapi_getresult
    public class GET_openapi_getresult : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;

        public GET_openapi_getresult(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
        }

        public override System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var openApiEndpoints = new WolverineWebApi.OpenApiEndpoints();
            
            // The actual HTTP request handler execution
            var result = openApiEndpoints.GetResult();

            return result.ExecuteAsync(httpContext);
        }
    }

    // END: GET_openapi_getresult
}