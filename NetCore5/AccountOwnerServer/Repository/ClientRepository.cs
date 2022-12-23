using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class ClientRepository :RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Client> GetAllClient()
        {
            return FindAll()
                .OrderBy(c => c.Name)
                .ToList();
        }

        public Client GetClientById(int IdClientBase)
        {
            return FindByCondition(client => client.IdClientBase.Equals(IdClientBase))
             .FirstOrDefault();
        }

        public Client GetClientByDetaills(int IdClientBase)
        {
            return FindByCondition(client => client.IdClientBase.Equals(IdClientBase))
             .Include(cc =>cc.ClientCycles)
             .FirstOrDefault();
        }

        public Client GetClientByDetaillsWithProductType(int IdClientBase)
        {
            return FindByCondition(client => client.IdClientBase.Equals(IdClientBase))
             .Include(cc => cc.ClientCycles)
             .ThenInclude(prd => prd.ProductType)
             .FirstOrDefault();
        }
    }
}
