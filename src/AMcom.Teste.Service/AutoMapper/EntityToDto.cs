using AMcom.Teste.DAL;
using AutoMapper;

namespace AMcom.Teste.Service.AutoMapper
{
    public class EntityToDto : Profile
    {
        public EntityToDto()
        {
            CreateMap<Ubs, UbsDTO>();
        }
    }
}
