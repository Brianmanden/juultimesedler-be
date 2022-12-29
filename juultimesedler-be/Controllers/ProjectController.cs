using juultimesedler_be.DTOs;
using juultimesedler_be.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace juultimesedler_be.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectsService _projectsService;

        public ProjectController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet("api/projects/")]
        public List<GetProjectDTO> GetCurrentProjects()
        {
            List<GetProjectDTO> allProjectsList = new();
            var allProjects = _projectsService.GetCurrentProjects();

            foreach (var project in allProjects)
            {
                // TODO Set project fullname
                allProjectsList.Add(new GetProjectDTO
                {
                    ProjectId = project.Id,
                    ProjectName = project.Name,
                    ProjectFullName = "project Fullname TODO" + project.Name,
                });
            }

            return allProjectsList;
        }

        [HttpGet("api/projects/{workerId}")]
        public List<GetProjectDTO> GetProjectsByWorkerId(int workerId)
        {
            List<GetProjectDTO> assignedProjects = new();
            var workersProjects = _projectsService.GetProjectsByWorkerId(workerId);

            foreach (var project in workersProjects)
            {
                // TODO Set project fullname
                assignedProjects.Add(new GetProjectDTO
                {
                    ProjectId = project.Id,
                    ProjectName = project.Name,
                    ProjectFullName = "project Fullname TODO" + project.Name,
                });
            }

            return assignedProjects;
        }

        [HttpPost("api/projects")]
        public TimeSheetDTO UpsertProject([FromBody]TimeSheetDTO project)
        {
            // TODO UpsertProject
            var bp = "";

            return project;
        }
    }
}
