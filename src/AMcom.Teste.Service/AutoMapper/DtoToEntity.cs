using AMcom.Teste.DAL;
using AutoMapper;

namespace AMcom.Teste.Service.AutoMapper
{
    public class DtoToEntity : Profile
    {
        public DtoToEntity()
        {
            CreateMap<UbsDTO, Ubs>();
        }
    }
}
