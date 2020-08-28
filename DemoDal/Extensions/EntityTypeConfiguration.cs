using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.Dal.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
