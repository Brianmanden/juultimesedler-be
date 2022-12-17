using Umbraco.Cms.Core.Models;

namespace juultimesedler_be.Interfaces
{
    public interface ProjectsInterface
    {
        public IEnumerable<IContent> GetProjects();
    }
}
