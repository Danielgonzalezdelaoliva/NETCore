using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        /*
         
         podemos agegar clients, productos, actualizar clicos de clientes todo en un  solo método, 
         y luego simplemente llamar al método Guardar una vez. Se aplicarán todos los cambios o, 
         si algo falla, se revertirán todos los cambios.

         */
        private RepositoryContext _repoContext;
        private IClientRepository _client;
        private IProductTypeRepository _productType;
        private IClientCycleRepository _clientCycle;

        public IClientRepository Client
        {
            get
            {
                if (_client == null)
                {
                    _client = new ClientRepository(_repoContext);
                }
                return _client;
            }
        }

        public IProductTypeRepository ProductType
        {
            get
            {
                if (_productType == null)
                {
                    _productType = new ProductTypeRepository(_repoContext);
                }
                return _productType;
            }
        }

        public IClientCycleRepository ClientCycle
        {
            get
            {
                if (_clientCycle == null)
                {
                    _clientCycle = new ClientCycleRepository(_repoContext);
                }
                return _clientCycle;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
