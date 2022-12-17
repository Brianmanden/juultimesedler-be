using juultimesedler_be.Interfaces;
using NPoco;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Services
{
    public class ProjectsService : IProjectsService
    {
        private IContentService _contentService;

        public ProjectsService(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IEnumerable<IContent> GetProjects() {
            int projectsFolderId = 
                _contentService
                    .GetRootContent()
                    .Where(node => node.ContentType.Alias == "projects")
                    .FirstOrDefault()
                    .Id;

            long totalProjects;
            IEnumerable<IContent> projects =
                _contentService
                    .GetPagedDescendants(projectsFolderId, 0, 1000, out totalProjects)
                    .Where(node => node.ContentType.Alias == "project");

            return projects;
        }

        // TODO
        public IEnumerable<IContent> GetProjectsByWorkerId(int workerId) {
            var projectsAssignedToWorker =
                GetProjects();

            return projectsAssignedToWorker;
        }
    }
}
