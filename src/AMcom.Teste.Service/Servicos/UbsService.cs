using AMcom.Teste.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AMcom.Teste.Service
{
    public class UbsService : IServicesUbs
    {

        // Implemente um método que retorne as 5 UBSs mais próximas de um ponto (latitude e longitude) que devem 
        // ser passados como parâmetro para o método e retorne uma lista/coleção de objetos do tipo UbsDTO.
        // Esta lista deve estar ordenada pela avaliação (da melhor para a pior) de acordo com os dados que constam
        // no objeto retornado pela camada de acesso a dados (DAL).
        private readonly IRespositoryUbs _respository;
        private readonly IMapper _mapper;

        public UbsService(IRespositoryUbs respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }

        public IEnumerable<UbsDTO> Selecionar(double latitude, double longitude)
        {
            var ubsList = _respository.Selecionar(latitude, longitude)
                                      .OrderBy(x => x.Avaliacao);

            return _mapper.Map<IEnumerable<UbsDTO>>(ubsList);
        }

        public IEnumerable<UbsDTO> Selecionar(double latitude, double longitude, int quantidadeRetorno = 5)
        {
            var ubsList = _respository.Selecionar(latitude, longitude, quantidadeRetorno)
                                      .OrderBy(x => x.Avaliacao);

            return _mapper.Map<IEnumerable<UbsDTO>>(ubsList);
        }
    }
}
