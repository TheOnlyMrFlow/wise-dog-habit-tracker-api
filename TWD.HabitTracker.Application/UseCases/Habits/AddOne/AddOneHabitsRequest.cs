using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Application.UseCases.Habits.AddOne;

public class AddOneHabitRequest
{
    public AddOneHabitRequest(LoggedUser loggedUser, string habitName, AddOneHabitObjectiveRequest? objectiveRequest)
    {
        LoggedUser = loggedUser;
        HabitName = habitName;
        ObjectiveRequest = objectiveRequest;
    }
    
    public LoggedUser LoggedUser { get; }
    
    public string HabitName { get; }

    public AddOneHabitObjectiveRequest? ObjectiveRequest { get; set; }

    public class AddOneHabitObjectiveRequest
    {
        public AddOneHabitObjectiveRequest(decimal objectiveValue, string? objectiveUnit)
        {
            ObjectiveValue = objectiveValue;
            ObjectiveUnit = objectiveUnit;
        }

        public decimal ObjectiveValue { get;}
        
        public string? ObjectiveUnit { get; }
    }
}