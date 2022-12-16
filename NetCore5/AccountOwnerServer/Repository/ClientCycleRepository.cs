using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ClientCycleRepository: RepositoryBase<ClientCycle>, IClientCycleRepository
    {
        public ClientCycleRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
