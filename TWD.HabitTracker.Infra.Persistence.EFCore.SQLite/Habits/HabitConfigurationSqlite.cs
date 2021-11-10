using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Infra.Persistence.EFCore.Habits;

namespace TWD.HabitTracker.Persistence.EFCore.SQLite.Habits;

public class HabitConfigurationSqlite : HabitConfigurationBase
{
    public override void Configure(EntityTypeBuilder<Habit> builder)
    {
        base.Configure(builder);

        builder.ToTable("Habits");
    }
}