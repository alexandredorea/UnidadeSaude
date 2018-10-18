
using System.Collections.Generic;

namespace AMcom.Teste.Service
{
    public interface IServicesUbs 
    {
        IEnumerable<UbsDTO> Selecionar(double latitude, double longitude);
        IEnumerable<UbsDTO> Selecionar(double latitude, double longitude, int quantidadeRetorno = 5);
    }
}