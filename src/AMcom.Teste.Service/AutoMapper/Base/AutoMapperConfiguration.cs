using AutoMapper;

namespace AMcom.Teste.Service.AutoMapper.Base
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDto());
                cfg.AddProfile(new DtoToEntity());
            });
        }
    }
}
