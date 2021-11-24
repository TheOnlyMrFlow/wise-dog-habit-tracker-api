using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.User;

namespace TWD.HabitTracker.Application.Infra.Persistence.Users;

public interface IUserWriteRepository
{
    Task AddAsync(User user);
}