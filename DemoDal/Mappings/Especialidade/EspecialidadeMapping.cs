using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Demo.Dal.Extensions;

namespace Demo.Data.Mappings.Especialidade
{
    public class EspecialidadeMapping : EntityTypeConfiguration<Domain.Entitie.Especialidade.Especialidade>
    {
        public override void Map(EntityTypeBuilder<Domain.Entitie.Especialidade.Especialidade> builder)
        {
            builder.Property(c => c.Descricao)
              .IsRequired()
              .HasColumnType("varchar(255)");

            builder.HasOne(c => c.Medico).WithMany().HasForeignKey(c => c.MedicoId).IsRequired();

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(g => g.CascadeMode);

            builder.ToTable("Especialidades");
        }
    }
}
