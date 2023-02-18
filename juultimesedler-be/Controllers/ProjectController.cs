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

        public ProjectController(UmbracoHelper umbracoHelper)
        {
            _umbracoHelper = umbracoHelper;
        }
            
        [HttpGet("api/projects/")]
        public List<GetProjectDTO> GetCurrentProjects()
        {
            IPublishedContent rootNode = _umbracoHelper.ContentAtRoot().FirstOrDefault();
            IEnumerable<IPublishedContent> projects = rootNode.Children().DescendantsOrSelfOfType("project").ToList();

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
    }
}
