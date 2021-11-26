using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Entities.User;

namespace TWD.HabitTracker.Application.Infra.Persistence.Users;

public interface IUserReadRepository
{
    public Task<User> FindByDeviceTokenAsync(string deviceToken);
}