using juultimesedler_be.DTOs;
using juultimesedler_be.Interfaces;
using juultimesedler_be.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Controllers
{
    public class ProjectController : Controller
    {
        private IContentService _contentService;
        private IUserService _userService;
        private IProjectsService _projectsService;
        private IWorkersService _workersService;

        public ProjectController(IContentService contentService, IUserService userService, IProjectsService projectsService, IWorkersService workersService)
        {
            _contentService = contentService;
            _userService = userService;
            _projectsService = projectsService;
            _workersService = workersService;
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
            var bp = "";

            return project;
        }
    }
}
