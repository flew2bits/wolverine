// <auto-generated/>
#pragma warning disable

namespace Internal.Generated.WolverineHandlers
{
    // START: Outgoing1Handler1671730976
    public class Outgoing1Handler1671730976 : Wolverine.Runtime.Handlers.MessageHandler
    {


        public override System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            var outgoing1 = (PersistenceTests.Marten.Outgoing1)context.Envelope.Message;
            PersistenceTests.Marten.Outgoing1Handler.Handle(outgoing1);
            return System.Threading.Tasks.Task.CompletedTask;
        }

    }

    // END: Outgoing1Handler1671730976
    
    
}
