using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Application.UseCases.Habits.AddOne;

public class AddOneHabitRequest
{
    public AddOneHabitRequest(LoggedUser loggedUser, string habitName,  DateTime startDate, IEnumerable<DayOfWeek> weekDays, AddOneHabitObjectiveRequest? objectiveRequest)
    {
        LoggedUser = loggedUser;
        HabitName = habitName;
        ObjectiveRequest = objectiveRequest;
        StartDate = startDate;
        WeekDays = weekDays;
    }
    
    public LoggedUser LoggedUser { get; }
    
    public string HabitName { get; }

    public AddOneHabitObjectiveRequest? ObjectiveRequest { get; }
    
    public DateTime StartDate { get; }
    
    public IEnumerable<DayOfWeek> WeekDays { get; }

    public class AddOneHabitObjectiveRequest
    {
        public AddOneHabitObjectiveRequest(float objectiveValue, string? objectiveUnit)
        {
            ObjectiveValue = objectiveValue;
            ObjectiveUnit = objectiveUnit;
        }

        public float ObjectiveValue { get;}
        
        public string? ObjectiveUnit { get; }
    }
}