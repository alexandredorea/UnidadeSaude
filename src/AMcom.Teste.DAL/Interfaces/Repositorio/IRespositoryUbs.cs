using AMcom.Teste.DAL.Interfaces.Base;
using System.Collections.Generic;

namespace AMcom.Teste.DAL.Interfaces
{
    public interface IRespositoryUbs : IRepositoryBase<Ubs>
    {
        IEnumerable<Ubs> Selecionar(double latitude, double longitude);
        IEnumerable<Ubs> Selecionar(double latitude, double longitude, int quantidadeRetorno = 5);
    }
}
