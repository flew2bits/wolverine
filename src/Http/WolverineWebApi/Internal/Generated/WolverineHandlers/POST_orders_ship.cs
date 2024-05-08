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
    // START: POST_orders_ship
    public class POST_orders_ship : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Wolverine.Marten.Publishing.OutboxedSessionFactory _outboxedSessionFactory;
        private readonly Wolverine.Runtime.IWolverineRuntime _wolverineRuntime;

        public POST_orders_ship(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Wolverine.Marten.Publishing.OutboxedSessionFactory outboxedSessionFactory, Wolverine.Runtime.IWolverineRuntime wolverineRuntime) : base(wolverineHttpOptions)
        {
            _wolverineHttpOptions = wolverineHttpOptions;
            _outboxedSessionFactory = outboxedSessionFactory;
            _wolverineRuntime = wolverineRuntime;
        }

        public override async System.Threading.Tasks.Task Handle(Microsoft.AspNetCore.Http.HttpContext httpContext)
        {
            var messageContext = new Wolverine.Runtime.MessageContext(_wolverineRuntime);
            // Reading the request body via JSON deserialization
            var (command, jsonContinue) = await ReadJsonAsync<WolverineWebApi.Marten.ShipOrder>(httpContext);
            if (jsonContinue == Wolverine.HandlerContinuation.Stop) return;
            await using var documentSession = _outboxedSessionFactory.OpenSession(messageContext);
            var eventStore = documentSession.Events;
            
            // Loading Marten aggregate
            var eventStream = await eventStore.FetchForWriting<WolverineWebApi.Marten.Order>(command.OrderId, httpContext.RequestAborted).ConfigureAwait(false);

            var problemDetails1 = WolverineWebApi.Marten.CanShipOrderMiddleWare.Before(command, eventStream.Aggregate);
            // Evaluate whether the processing should stop if there are any problems
            if (!(ReferenceEquals(problemDetails1, Wolverine.Http.WolverineContinue.NoProblems)))
            {
                await WriteProblems(problemDetails1, httpContext).ConfigureAwait(false);
                return;
            }

            System.Guid id = default;
            System.Guid.TryParse(httpContext.Request.Query["id"], System.Globalization.CultureInfo.InvariantCulture, out id);
            
            // The actual HTTP request handler execution
            var orderShipped = WolverineWebApi.Marten.MarkItemEndpoint.Ship(command, eventStream.Aggregate);

            eventStream.AppendOne(orderShipped);
            await documentSession.SaveChangesAsync(httpContext.RequestAborted).ConfigureAwait(false);
            // Wolverine automatically sets the status code to 204 for empty responses
            if (!httpContext.Response.HasStarted) httpContext.Response.StatusCode = 204;
        }
    }

    // END: POST_orders_ship
    
    
}