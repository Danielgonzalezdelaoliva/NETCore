using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;

namespace AccountOwnerServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDTO>();
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<ClientCycle, ClientCycleDTO>();
        }
    }
}
