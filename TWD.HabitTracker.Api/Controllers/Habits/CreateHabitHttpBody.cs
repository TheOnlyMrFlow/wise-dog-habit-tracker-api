using System.ComponentModel.DataAnnotations;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Api.Controllers.Habits;

public class CreateHabitHttpBody
{
    public class CreateHabitObjectiveHttpRequestBody
    {
        [Required] public float? Value { get; set; } = null!;
        public string? Unit { get; set; }
        
        public AddOneHabitRequest.AddOneHabitObjectiveRequest ToApplicationRequest() => new(Value.Value, Unit);
    }
    
    [Required] public string Name { get; set; } = null!;
    public CreateHabitObjectiveHttpRequestBody? Objective { get; set; }
    [Required] public IEnumerable<DayOfWeek> WeekDays { get; set; } = null!;
    [Required] public DateTime? StartDate { get; set; } = null!;

    public AddOneHabitRequest ToApplicationRequest(LoggedUser loggedUser) => new(loggedUser, Name, StartDate.Value, WeekDays, Objective?.ToApplicationRequest());
}