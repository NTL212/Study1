using System;

namespace TaskProjectManagementPlatform.Domain.Entities
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done,
        Blocked
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High,
        Critical
    }

    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public string? AssignedToUserId { get; set; }
        public Guid ProjectId { get; set; }
        public Project Project { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserId { get; set; } = string.Empty;
    }
}
