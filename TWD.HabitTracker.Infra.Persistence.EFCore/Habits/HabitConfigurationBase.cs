using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Validators;

namespace TWD.HabitTracker.Infra.Persistence.EFCore.Habits;

public abstract class HabitConfigurationBase : IEntityTypeConfiguration<Habit>
{
    public virtual void Configure(EntityTypeBuilder<Habit> builder)
    {
        builder.Property(h => h.Name).HasMaxLength(HabitValidator.NameMaxLength);
    }
}