using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        public List<int> GetProjectsByWorkerId(int workerId)
        {
            // TODO: Create return DTO containing only needed information for FE
            List<int> assignedProjects = new();
            var projectsNode = _contentService.GetRootContent().Where(node => node.ContentType.Alias == "projects");
            var workerKey = _contentService.GetById(workerId).Key.ToString().Replace("-", "");

            long totalProjects;
            var projects = _contentService.GetPagedChildren(projectsNode.FirstOrDefault().Id, 0, 1000, out totalProjects);

            foreach (var project in projects)
            {
                foreach (var property in project.Properties.Where(prop => prop.Alias == "workers"))
                {
                    string[] userIds = property.Values.FirstOrDefault().PublishedValue.ToString().Split(",");
                    foreach (var userId in userIds)
                    {
                        if (userId.Contains(workerKey))
                        {
                            assignedProjects.Add(project.Id);
                        }
                    }
                }
            }

            return assignedProjects;
        }
    }
}
