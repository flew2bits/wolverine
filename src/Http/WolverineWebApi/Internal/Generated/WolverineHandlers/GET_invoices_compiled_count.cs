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
    // START: GET_invoices_compiled_count
    public class GET_invoices_compiled_count : Wolverine.Http.HttpHandler
    {
        private readonly Wolverine.Http.WolverineHttpOptions _wolverineHttpOptions;
        private readonly Wolverine.Marten.Publishing.OutboxedSessionFactory _outboxedSessionFactory;
        private readonly Wolverine.Runtime.IWolverineRuntime _wolverineRuntime;

        public GET_invoices_compiled_count(Wolverine.Http.WolverineHttpOptions wolverineHttpOptions, Wolverine.Marten.Publishing.OutboxedSessionFactory outboxedSessionFactory, Wolverine.Runtime.IWolverineRuntime wolverineRuntime) : base(wolverineHttpOptions)
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
            
            // The actual HTTP request handler execution
            var compiledCountQuery = WolverineWebApi.Marten.InvoicesEndpoint.GetCompiledCount();

            var result_of_QueryAsync = await documentSession.QueryAsync<WolverineWebApi.Marten.Invoice, int>(compiledCountQuery, httpContext.RequestAborted).ConfigureAwait(false);
            await Wolverine.Http.HttpHandler.WriteString(httpContext, result_of_QueryAsync.ToString()).ConfigureAwait(false);
        }
    }

    // END: GET_invoices_compiled_count
}