using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Demo.Dal.Extensions;

namespace Demo.Data.Mappings.Medico
{
    public class MedicoMapping : EntityTypeConfiguration<Domain.Entitie.Medico.Medico>
    {
        public override void Map(EntityTypeBuilder<Domain.Entitie.Medico.Medico> builder)
        {
            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(c => c.CPF)
              .IsRequired()
              .HasColumnType("varchar(11)");

            builder.Property(c => c.Crm)
              .IsRequired()
              .HasColumnType("varchar(255)");

            builder.Ignore(c => c.Especialidade);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(g => g.CascadeMode);

            builder.ToTable("Medicos");
        }
    }
}
