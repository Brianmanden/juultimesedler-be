using juultimesedler_be.Interfaces;
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
            var projects = 
                _contentService
                    .GetRootContent()
                    .Where(node => node.ContentType.Alias == "projects");

            return projects;
        }

        // TODO
        public IEnumerable<IContent> GetProjectsByWorkerId(int workerId) {
            var workerProjects = this.GetProjects().Where(project => project.ContentType.Alias == "thing");

            return workerProjects;
        }
    }
}
