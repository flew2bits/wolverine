// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_upload_file
    public class POST_upload_file : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;

        public POST_upload_file(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            // Retrieve header value from the request
            var file = ReadSingleFormFileValue(httpContext);
            
            // The actual HTTP request handler execution
            await WolverineWebApi.FileUploadEndpoint.Upload(file).ConfigureAwait(false);

            // Wolverine automatically sets the status code to 204 for empty responses
            if (!httpContext.Response.HasStarted) httpContext.Response.StatusCode = 204;
        }
    }

    // END: POST_upload_file
    
    
}