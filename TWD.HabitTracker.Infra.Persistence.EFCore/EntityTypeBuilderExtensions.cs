using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWD.HabitTracker.Domain.Entities;

namespace TWD.HabitTracker.Infra.Persistence.EFCore
{
    public static class EntityTypeBuilderExtensions
    {
        public static EntityTypeBuilder<TEntity> ConfigurePersistable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IPersistableEntity 
            => builder.ConfigureIdentifiable().ConfigureInternalIdentifiable();

        public static EntityTypeBuilder<TEntity> ConfigureInternalIdentifiable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IInternalIdentifiable
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            
            builder.HasIndex(b => b.InternalId).IsUnique().IsClustered();

            var prop = builder.Property(b => b.InternalId).UseIdentityColumn().IsRequired();
            prop.Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            return builder;
        }
        
        public static EntityTypeBuilder<TEntity> ConfigureIdentifiable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : class, IIdentifiable
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.HasKey(x => x.Id).IsClustered(false);
            builder.Property(b => b.Id).HasDefaultValueSql("newid()").IsRequired();

            return builder;
        }
    }
}