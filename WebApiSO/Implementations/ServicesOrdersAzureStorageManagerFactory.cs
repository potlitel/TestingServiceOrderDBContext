using FSA.Core.Interfaces;
using FSA.Core.Server.ServiceOrders.Implementations;

namespace WebApiSO.Implementations
{
    public class ServicesOrdersAzureStorageManagerFactory : ISOAzureStorageManagerFactory
    {
        private readonly IConfiguration configuration;

        public ServicesOrdersAzureStorageManagerFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IAzureStorageManager GetAzureStorageManager(string name)
        {
            if (1 == 0)
            {
            }

            IAzureStorageManager result = ((name == "ServiceOrderDocuments") ? new SODocsAzureStorageManager(configuration) : ((!(name == "ServiceOrderTaskDocuments")) ? ((IAzureStorageManager)new SODocsAzureStorageManager(configuration)) : ((IAzureStorageManager)new SOTDocsAzureStorageManager(configuration))));
            if (1 == 0)
            {
            }

            return result;
        }
    }
}
