// <auto-generated/>
#pragma warning disable
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using Wolverine.Http;
using Wolverine.Marten.Publishing;
using Wolverine.Runtime;

namespace Internal.Generated.WolverineHandlers
{
    // START: POST_orders_create2
    public class POST_orders_create2 : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Wolverine.Marten.Publishing.OutboxedSessionFactory _outboxedSessionFactory;
        private readonly Wolverine.Runtime.IWolverineRuntime _wolverineRuntime;

        public POST_orders_create2(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Wolverine.Marten.Publishing.OutboxedSessionFactory outboxedSessionFactory, Wolverine.Runtime.IWolverineRuntime wolverineRuntime) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
            _outboxedSessionFactory = outboxedSessionFactory;
            _wolverineRuntime = wolverineRuntime;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var messageContext = new Wolverine.Runtime.MessageContext(_wolverineRuntime);
            // Building the Marten session
            await using var documentSession = _outboxedSessionFactory.OpenSession(messageContext);
            // Catches any existing stream id collision exceptions
            try
            {
                // Reading the request body via JSON deserialization
                var (command, jsonContinue) = await ReadJsonAsync<WolverineWebApi.Marten.StartOrder>(httpContext);
                if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
                
                // The actual HTTP request handler execution
                (var orderStatus_response, var startStream) = WolverineWebApi.Marten.MarkItemEndpoint.StartOrder2(command, documentSession);

                if (startStream != null)
                {
                    
                    // Placed by Wolverine's ISideEffect policy
                    startStream.Execute(documentSession);

                }

                
                // Commit any outstanding Marten changes
                await documentSession.SaveChangesAsync(httpContext.RequestAborted).ConfigureAwait(false);

                
                // Have to flush outgoing messages just in case Marten did nothing because of https://github.com/JasperFx/wolverine/issues/536
                await messageContext.FlushOutgoingMessagesAsync().ConfigureAwait(false);

                // Writing the response body to JSON because this was the first 'return variable' in the method signature
                await WriteJsonAsync(httpContext, orderStatus_response);
            }

            catch(Marten.Exceptions.ExistingStreamIdCollisionException e)
            {
                await WolverineWebApi.Marten.StreamCollisionExceptionPolicy.RespondWithProblemDetails(e, httpContext);
                return;
            }
        }
    }

    // END: POST_orders_create2
}