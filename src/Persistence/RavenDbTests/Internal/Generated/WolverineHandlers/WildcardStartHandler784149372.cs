// <auto-generated/>
#pragma warning disable
using Raven.Client.Documents;

namespace Internal.Generated.WolverineHandlers
{
    // START: WildcardStartHandler784149372
    public class WildcardStartHandler784149372 : Wolverine.Runtime.Handlers.MessageHandler
    {
        private readonly Raven.Client.Documents.IDocumentStore _documentStore;

        public WildcardStartHandler784149372(Raven.Client.Documents.IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }



        public override async System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            using var asyncDocumentSession = _documentStore.OpenAsyncSession();
            // The actual message body
            var wildcardStart = (Wolverine.ComplianceTests.Sagas.WildcardStart)context.Envelope.Message;

            var stringBasicWorkflow = new Wolverine.ComplianceTests.Sagas.StringBasicWorkflow();
            
            // The actual message execution
            stringBasicWorkflow.Starts(wildcardStart);

            if (!stringBasicWorkflow.IsCompleted())
            {
                await asyncDocumentSession.StoreAsync(stringBasicWorkflow, cancellation).ConfigureAwait(false);
            }

            
            // Commit all pending changes
            await asyncDocumentSession.SaveChangesAsync(cancellation).ConfigureAwait(false);

        }

    }

    // END: WildcardStartHandler784149372
    
    
}

