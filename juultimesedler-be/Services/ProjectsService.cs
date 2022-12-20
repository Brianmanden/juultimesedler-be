using juultimesedler_be.Interfaces;
using NPoco;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace juultimesedler_be.Services
{
    public class ProjectsService : IProjectsService
    {
        private IContentService _contentService;
        private IWorkersService _workersService;

        public ProjectsService(IContentService contentService, IWorkersService workersService)
        {
            _contentService = contentService;
            _workersService = workersService;
        }

        public IEnumerable<IContent> GetProjects()
        {
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

        public IList<IContent> GetProjectsByWorkerId(int workerId)
        {
            IEnumerable<IContent> allProjects = GetProjects();
            List<IContent> projectsAssignedToWorker = new();

            string workerKey = _workersService.GetWorkerKey(workerId);

            foreach (var project in allProjects)
            {
                foreach (var property in project.Properties)
                {
                    if (property.Alias == "workers")
                    {
                        string? workerKeysAssignedToProject = property.Values.FirstOrDefault()?.EditedValue?.ToString();

                        string? editedValue = property.Values.First()?.EditedValue?.ToString();
                        if (!String.IsNullOrWhiteSpace(editedValue) && editedValue.Contains(workerKey))
                        {
                            projectsAssignedToWorker.Add(project);
                        }

                    }
                }
            }
            return projectsAssignedToWorker;
        }
    }
}
