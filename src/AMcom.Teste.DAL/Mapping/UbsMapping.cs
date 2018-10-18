using AMcom.Teste.DAL.Mapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AMcom.Teste.DAL.Mapping
{
    public class UbsMapping : EntityBaseMapping<Ubs>
    {
        public override void Configure(EntityTypeBuilder<Ubs> builder)
        {
            base.Configure(builder);

            builder.ToTable("UnidadeBasicaSaude");

            builder.Property(x => x.Latitude)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Longitude)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Endereco)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Cidade)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Avaliacao)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Ignore(x => x.Distancia);
        }
    }
}
