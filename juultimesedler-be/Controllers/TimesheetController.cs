using juultimesedler_be.DTOs;
using juultimesedler_be.Services;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Controllers
{
    public class TimesheetController : Controller
    {
        private IContentService _contentService;

        public TimesheetController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost("api/timesheets")]
        public TimeSheetDTO UpsertTimesheet([FromBody] TimeSheetDTO timesheet)
        {
            TimeService timeService = new TimeService();
            string formattedYearAndWeek = timeService.FormattedCurrentYearAndWeek();

            var currentProject = _contentService.GetById(timesheet.SelectedProjectId);
            //currentProject.SetValue("fullName", "new fullname value");
            currentProject.SetValue("fullName", formattedYearAndWeek + " - new fullname value");
            currentProject.SetValue("address", "new address value");

            _contentService.SaveAndPublish(currentProject);
            return timesheet;
        }
    }
}
