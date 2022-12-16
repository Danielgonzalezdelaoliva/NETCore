using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IClientRepository: IRepositoryBase<Client>
    {
        IEnumerable<Client> GetAllClient();
        Client GetClientById(int IdClientBase);
    }
}
