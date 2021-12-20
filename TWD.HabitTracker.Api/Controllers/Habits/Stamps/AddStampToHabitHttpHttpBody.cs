using System.ComponentModel.DataAnnotations;
using TWD.HabitTracker.Application.UseCases.Habits.AddOne;
using TWD.HabitTracker.Application.UseCases.Habits.Stamps.AddOne;
using TWD.HabitTracker.Domain.Entities.User.Auth;

namespace TWD.HabitTracker.Api.Controllers.Habits.Stamps;

public class AddStampToHabitHttpHttpBody
{
    [Required] public DateTime Date { get; set; }
    
    public decimal Value { get; set; }
    
    public AddStampToHabitRequest ToApplicationRequest(LoggedUser loggedUser, Guid habitId) => new(loggedUser, habitId, Date, Value);
}