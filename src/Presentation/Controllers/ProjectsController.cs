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
    public class ProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectDto>>> GetProjects()
        {
            var projects = await _context.Projects
                .Include(p => p.Tasks)
                .ToListAsync();

            var projectDtos = projects.Select(p => new ProjectDto
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt,
                CreatedByUserId = p.CreatedByUserId,
                Tasks = p.Tasks?.Select(t => new TaskDto
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status.ToString(),
                    Priority = t.Priority.ToString(),
                    AssignedToId = t.AssignedToUserId,
                    ProjectId = t.ProjectId.ToString()
                }).ToList() ?? new List<TaskDto>()
            }).ToList();

            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDto>> GetProject(Guid id)
        {
            var project = await _context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            var projectDto = new ProjectDto
            {
                Id = project.Id.ToString(),
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt,
                CreatedByUserId = project.CreatedByUserId,
                Tasks = project.Tasks?.Select(t => new TaskDto
                {
                    Id = t.Id.ToString(),
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    Status = t.Status.ToString(),
                    Priority = t.Priority.ToString(),
                    AssignedToId = t.AssignedToUserId,
                    ProjectId = t.ProjectId.ToString()
                }).ToList() ?? new List<TaskDto>()
            };

            return Ok(projectDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(CreateProjectDto createProjectDto)
        {
            var project = new Project
            {
                Name = createProjectDto.Name,
                Description = createProjectDto.Description,
                CreatedAt = DateTime.UtcNow,
                CreatedByUserId = User.Identity?.Name ?? "Unknown"
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProject(Guid id, UpdateProjectDto updateProjectDto)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            project.Name = updateProjectDto.Name ?? project.Name;
            project.Description = updateProjectDto.Description ?? project.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
