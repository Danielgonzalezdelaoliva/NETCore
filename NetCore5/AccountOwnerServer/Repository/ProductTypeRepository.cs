using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class ProductTypeRepository: RepositoryBase<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
