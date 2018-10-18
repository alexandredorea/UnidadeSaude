using AMcom.Teste.DAL.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMcom.Teste.DAL.Mapping.Base
{
    public class EntityBaseMapping<TipoEntidade> : IEntityTypeConfiguration<TipoEntidade> where TipoEntidade : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TipoEntidade> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
