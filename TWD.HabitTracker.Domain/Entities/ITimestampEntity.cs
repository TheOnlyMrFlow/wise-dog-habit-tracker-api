namespace TWD.HabitTracker.Domain.Entities
{
    public interface ITimestampEntity
    {
        DateTime CreatedAt { get; set; }
        
        DateTime UpdatedAt { get; set; }
    }
}