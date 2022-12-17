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

        public ProjectController(IContentService contentService, IUserService userService, IProjectsService projectsService)
        {
            _contentService = contentService;
            _userService = userService;
            _projectsService = projectsService;
        }

        [HttpGet("api/projects/{workerId}")]
        public List<GetProjectDTO> GetProjectsByWorkerId(int workerId)
        {
            List<GetProjectDTO> assignedProjects = new();
            var projects = _projectsService.GetProjects();

            // TODO
            var workersProjects = _projectsService.GetProjectsByWorkerId(1106);

            var workerKey = _userService.GetUserById(workerId)?.Key.ToString().Replace("-", "");

            long totalProjects;

            //var projects = _contentService.GetPagedChildren(projects.FirstOrDefault().Id, 0, 1000, out totalProjects);

            //foreach (var project in projects)
            //{
            //    string[]? workers = project.GetValue("workers")?.ToString().Split(',');

            //    if (workers != null && workers.Any(worker => worker.Contains(workerKey)))
            //    {
            //        string projectFullName = project.GetValue("fullName")?.ToString() ?? "No full name for project!";
            //        assignedProjects.Add(new GetProjectDTO
            //        {
            //            ProjectId = project.Id,
            //            ProjectName = project.Name,
            //            ProjectFullName = projectFullName,
            //        });
            //    }
            //}

            ////var returnProjects = assignedProjects.Where(ap => projectsNode.Any(pn => pn.Id == ap));

            return assignedProjects;
        }

        //[EnableCors("AllowDashboardOrigin")]
        //[HttpPost("api/projects")]
        //public ActionResult UpdateTimeSheet(TimeSheetDTO data)
        //{
        //    var bp = "";

        //    return Ok();
        //}

        [EnableCors("AllowDashboardOrigin")]
        [HttpPost("api/projects")]
        public ActionResult UpdateTimeSheet(string data)
        {
            var bp = "";

            return Ok();
        }
    }
}
