using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TWD.HabitTracker.Domain.ValueObjects.Email;

namespace TWD.HabitTracker.Infra.Persistence.EFCore
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<Email> HasEmailConversion(this PropertyBuilder<Email> propertyBuilder)
            => propertyBuilder
                .HasConversion(email => email.Value, v => new Email(v))
                .HasMaxLength(Email.EmailMaxLength);
    }
}