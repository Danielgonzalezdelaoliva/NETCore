using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    //envolvemos en una interfase todos los repositorios para poder a todos ellos desde un mismo controlador
    public interface IRepositoryWrapper
    {
        IClientRepository Client { get; }
        IClientCycleRepository ClientCycle { get; }
        IProductTypeRepository ProductType { get; }
        void Save();
    }
}
