using DomainValidationCore.Validation;
using TWD.HabitTracker.Domain.Entities.Habits;
using TWD.HabitTracker.Domain.Validators.ValidationSpecs;

namespace TWD.HabitTracker.Domain.Validators
{
    public sealed class HabitValidator : Validator<Habit>
    {
        public const int NameMaxLength = 127; 
            
        public HabitValidator()
        {
            Add("SummaryIsNotNullOrWhiteSpace", new Rule<Habit>(new IsNotNullValidationSpec<Habit>((x => x.Name)), "Summary field is missing."));
            Add("SummaryIsLessThan200CharacterLong", new Rule<Habit>(new IsTrueValidationSpec<Habit>(x => x.Name.Length <= NameMaxLength), "Habit name is longer than 200 characters."));
        }
    }
}