using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskProjectManagementPlatform.Application.DTOs;
using TaskProjectManagementPlatform.Infrastructure.Data;
using TaskProjectManagementPlatform.Domain.Entities;

namespace TaskProjectManagementPlatform.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
        {
            var tasks = await _context.Tasks
                .Include(t => t.Project)
                .ToListAsync();

            var taskDtos = tasks.Select(t => new TaskDto
            {
                Id = t.Id.ToString(),
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Status = t.Status.ToString(),
                Priority = t.Priority.ToString(),
                AssignedToId = t.AssignedToUserId,
                ProjectId = t.ProjectId.ToString()
            }).ToList();

            return Ok(taskDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetTask(Guid id)
        {
            var task = await _context.Tasks
                .Include(t => t.Project)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            var taskDto = new TaskDto
            {
                Id = task.Id.ToString(),
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Status = task.Status.ToString(),
                Priority = task.Priority.ToString(),
                AssignedToId = task.AssignedToUserId,
                ProjectId = task.ProjectId.ToString()
            };

            return Ok(taskDto);
        }

        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            var project = await _context.Projects.FindAsync(Guid.Parse(createTaskDto.ProjectId));
            if (project == null)
            {
                return BadRequest("Invalid project ID");
            }

            var task = new TaskItem
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                DueDate = createTaskDto.DueDate,
                Status = TaskProjectManagementPlatform.Domain.Entities.TaskStatus.ToDo,
                Priority = createTaskDto.Priority,
                AssignedToUserId = createTaskDto.AssignedToUserId,
                ProjectId = Guid.Parse(createTaskDto.ProjectId)
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(Guid id, UpdateTaskDto updateTaskDto)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            task.Title = updateTaskDto.Title ?? task.Title;
            task.Description = updateTaskDto.Description ?? task.Description;
            task.DueDate = updateTaskDto.DueDate ?? task.DueDate;
            task.Status = updateTaskDto.Status ?? task.Status;
            task.Priority = updateTaskDto.Priority ?? task.Priority;
            task.AssignedToUserId = updateTaskDto.AssignedToUserId ?? task.AssignedToUserId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasksByProject(Guid projectId)
        {
            var tasks = await _context.Tasks
                .Where(t => t.ProjectId == projectId)
                .ToListAsync();

            var taskDtos = tasks.Select(t => new TaskDto
            {
                Id = t.Id.ToString(),
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Status = t.Status.ToString(),
                Priority = t.Priority.ToString(),
                AssignedToId = t.AssignedToUserId,
                ProjectId = t.ProjectId.ToString()
            }).ToList();

            return Ok(taskDtos);
        }
    }
}
