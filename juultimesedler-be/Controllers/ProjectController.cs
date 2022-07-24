using juultimesedler_be.DTOs;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Controllers
{
    public class ProjectController : Controller
    {
        private IContentService _contentService;

        public ProjectController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet("api/projects/{workerId}")]
        public List<GetProjectDTO> GetProjectsByWorkerId(int workerId)
        {
            List<GetProjectDTO> assignedProjects = new();
            var projectsNode = _contentService.GetRootContent().Where(node => node.ContentType.Alias == "projects");
            var workerKey = _contentService.GetById(workerId)?.Key.ToString().Replace("-", "");

            long totalProjects;
            var projects = _contentService.GetPagedChildren(projectsNode.FirstOrDefault().Id, 0, 1000, out totalProjects);

            foreach (var project in projects)
            {
                string[]? workers = project.GetValue("workers")?.ToString().Split(',');

                if (workers != null && workers.Any(worker => worker.Contains(workerKey)))
                {
                    string projectFullName = project.GetValue("fullName")?.ToString() ?? "No full name for project!";
                    assignedProjects.Add(new GetProjectDTO
                    {
                        ProjectId = project.Id,
                        ProjectName = project.Name,
                        ProjectFullName = projectFullName,
                    });
                }
            }

            //var returnProjects = assignedProjects.Where(ap => projectsNode.Any(pn => pn.Id == ap));

            return assignedProjects;
        }
    }
}
