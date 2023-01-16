using juultimesedler_be.DTOs;
using juultimesedler_be.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;

namespace juultimesedler_be.Controllers
{
    public class ProjectController : Controller
    {
        private readonly UmbracoHelper _umbracoHelper;
        private IContentService _contentService;

        public ProjectController(UmbracoHelper umbracoHelper, IContentService contentService)
        {
            _umbracoHelper = umbracoHelper;
            _contentService = contentService;
        }

        [HttpGet("api/projects/")]
        public List<GetProjectDTO> GetCurrentProjects()
        {
            TimeService timeService = new TimeService();
            string formattedYearAndWeek = timeService.FormattedCurrentYearAndWeek();

            IPublishedContent rootNode = _umbracoHelper.ContentAtRoot().FirstOrDefault();
            IEnumerable<IPublishedContent> projects = rootNode.Children().ToList();
            List<GetProjectDTO> allProjectsList = new();

            foreach (var project in projects)
            {
                allProjectsList.Add(new GetProjectDTO
                {
                    //someProperty = project.Value("contactPerson / address / description / contactPerson")?.ToString()
                    ProjectId = project.Id,
                    ProjectName = project.Name,
                    ProjectFullName = project.Value("fullName")?.ToString(),
                });
            }

            return allProjectsList;
        }

        [HttpPost("api/projects")]
        public TimeSheetDTO UpsertProject([FromBody]TimeSheetDTO project)
        {
            TimeService timeService = new TimeService();
            string formattedYearAndWeek = timeService.FormattedCurrentYearAndWeek();

            var currentProject = _contentService.GetById(project.SelectedProjectId);
            //currentProject.SetValue("fullName", "new fullname value");
            currentProject.SetValue("fullName", formattedYearAndWeek + " - new fullname value");
            currentProject.SetValue("address", "new address value");

            _contentService.SaveAndPublish(currentProject);
            return project;
        }
    }
}
