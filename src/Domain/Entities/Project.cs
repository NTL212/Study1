using System;
using System.Collections.Generic;

namespace TaskProjectManagementPlatform.Domain.Entities
{
    public class Project
    {
        public Project()
        {
            Name = string.Empty;
            Description = string.Empty;
            CreatedByUserId = string.Empty;
            Tasks = new List<TaskItem>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
