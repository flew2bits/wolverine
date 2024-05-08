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
    // START: POST_orders_orderId_ship3
    public class POST_orders_orderId_ship3 : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Wolverine.Marten.Publishing.OutboxedSessionFactory _outboxedSessionFactory;
        private readonly Wolverine.Runtime.IWolverineRuntime _wolverineRuntime;

        public POST_orders_orderId_ship3(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Wolverine.Marten.Publishing.OutboxedSessionFactory outboxedSessionFactory, Wolverine.Runtime.IWolverineRuntime wolverineRuntime) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
            _outboxedSessionFactory = outboxedSessionFactory;
            _wolverineRuntime = wolverineRuntime;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            if (!System.Guid.TryParse((string)httpContext.GetRouteValue("orderId"), out var orderId))
            {
                httpContext.Response.StatusCode = 404;
                return;
            }

            var messageContext = new Wolverine.Runtime.MessageContext(_wolverineRuntime);
            await using var documentSession = _outboxedSessionFactory.OpenSession(messageContext);
            var eventStore = documentSession.Events;
            var eventStream = await documentSession.Events.FetchForWriting<WolverineWebApi.Marten.Order>(orderId, httpContext.RequestAborted);
            if (eventStream.Aggregate == null)
            {
                await Microsoft.AspNetCore.Http.Results.NotFound().ExecuteAsync(httpContext);
                return;
            }
            
            // The actual HTTP request handler execution
            var orderShipped = WolverineWebApi.Marten.MarkItemEndpoint.Ship3(eventStream.Aggregate);

            eventStream.AppendOne(orderShipped);
            await documentSession.SaveChangesAsync(httpContext.RequestAborted).ConfigureAwait(false);
            // Wolverine automatically sets the status code to 204 for empty responses
            if (!httpContext.Response.HasStarted) httpContext.Response.StatusCode = 204;
        }
    }

    // END: POST_orders_orderId_ship3
    
    
}