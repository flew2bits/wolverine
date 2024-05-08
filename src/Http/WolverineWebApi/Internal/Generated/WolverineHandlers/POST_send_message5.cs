// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;
using Wolverine.Runtime;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_send_message5
    public class POST_send_message5 : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Wolverine.Runtime.IWolverineRuntime _wolverineRuntime;

        public POST_send_message5(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Wolverine.Runtime.IWolverineRuntime wolverineRuntime) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
            _wolverineRuntime = wolverineRuntime;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var sendingEndpoint = new Wolverine.Http.Runtime.SendingEndpoint<WolverineWebApi.HttpMessage5>();
            var messageContext = new Wolverine.Runtime.MessageContext(_wolverineRuntime);
            Wolverine.Http.Runtime.RequestIdMiddleware.Apply(httpContext, messageContext);
            // Reading the request body via JSON deserialization
            var (message, jsonContinue) = await ReadJsonAsync<WolverineWebApi.HttpMessage5>(httpContext);
            if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
            
            // The actual HTTP request handler execution
            var result_of_SendAsync = await sendingEndpoint.SendAsync(message, messageContext, httpContext.Response);

            await WriteString(httpContext, result_of_SendAsync);
        }
    }

    // END: POST_send_message5
    
    
}