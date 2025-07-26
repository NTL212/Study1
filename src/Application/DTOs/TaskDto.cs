using System;
using TaskProjectManagementPlatform.Domain.Entities;
using TaskStatus = TaskProjectManagementPlatform.Domain.Entities.TaskStatus;
using TaskPriority = TaskProjectManagementPlatform.Domain.Entities.TaskPriority;

namespace TaskProjectManagementPlatform.Application.DTOs
{
    public class TaskDto
    {
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } = TaskStatus.ToDo.ToString();
        public string Priority { get; set; } = TaskPriority.Medium.ToString();
        public string? AssignedToId { get; set; }
        public string ProjectId { get; set; } = string.Empty;
        public string? CreatedByUserId { get; set; }
    }

    public class CreateTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? DueDate { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public string? AssignedToUserId { get; set; }
        public string ProjectId { get; set; } = string.Empty;
    }

    public class UpdateTaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus? Status { get; set; }
        public TaskPriority? Priority { get; set; }
        public string? AssignedToUserId { get; set; }
    }
}
