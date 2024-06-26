// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_go
    public class POST_go : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;

        public POST_go(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
        }

        public override System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var fakeEndpoint = new WolverineWebApi.FakeEndpoint();
            
            // The actual HTTP request handler execution
            fakeEndpoint.Go();

            // Wolverine automatically sets the status code to 204 for empty responses
            if (!httpContext.Response.HasStarted) httpContext.Response.StatusCode = 204;
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }

    // END: POST_go
    
    
}