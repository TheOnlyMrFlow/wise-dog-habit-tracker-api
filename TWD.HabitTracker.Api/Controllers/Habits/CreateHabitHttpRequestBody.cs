using System.ComponentModel.DataAnnotations;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Api.Controllers.Habits;

public class CreateHabitHttpRequestBody
{
    public class CreateHabitObjectiveHttpRequestBody
    {
        [Required] public decimal Value { get; set; }
        public string? Unit { get; set; }
        
        public AddOneHabitRequest.AddOneHabitObjectiveRequest ToApplicationRequest() => new(Value, Unit);
    }
    
    [Required] public string Name { get; set; } = null!;
    public CreateHabitObjectiveHttpRequestBody? Objective { get; set; }
    
    public AddOneHabitRequest ToApplicationRequest(LoggedUser loggedUser) => new(loggedUser, Name, Objective?.ToApplicationRequest());
}