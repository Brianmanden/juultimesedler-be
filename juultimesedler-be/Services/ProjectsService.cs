using juultimesedler_be.Interfaces;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Services
{
    public class ProjectsService : ProjectsInterface
    {
        private IContentService _contentService;

        public ProjectsService(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IEnumerable<IContent> GetProjects() {
            return _contentService.GetRootContent().Where(node => node.ContentType.Name == "ProjectsFolder");
        }
    }
}
