using juultimesedler_be.DTOs;
//using juultimesedler_be.Models;
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

        [HttpGet("api/gettimesheetweek")]
        public GetTimesheetWeekDTO GetCurrentTimesheetWeek()
        {
            TimeService timeService = new();
            GetTimesheetWeekDTO timesheetWeek = timeService.GetCurrentTimesheetWeek();
            return timesheetWeek;
        }

        [HttpPut("api/timesheets")]
        public PutTimeSheetDTO UpsertTimesheet([FromBody] PutTimeSheetDTO weekTimesheet)
        {
            TimeService timeService = new();
            string formattedYearAndWeek = timeService.FormattedCurrentYearAndWeek();

            // TODO BJA - Check for workdays, maybe refactor into service ?
 
            //var currentProject = _contentService.GetById(timesheet.SelectedProjectId);
            ////currentProject.SetValue("fullName", "new fullname value");
            //currentProject.SetValue("fullName", formattedYearAndWeek + " - new fullname value");
            //currentProject.SetValue("address", "new address value");

            //_contentService.SaveAndPublish(currentProject);
            return weekTimesheet;
        }
    }
}
