using juultimesedler_be.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Controllers
{
    public class HomeController : Controller
    {
        private IContentService _contentService;

        public HomeController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpPost("api/test")]
        //public IActionResult Index([FromBody] object data)
        public object Index([FromBody] TimeSheetDTO data)
        {
            var bp = "";

            DateTime dt = DateTime.Now;
            Calendar cal = new CultureInfo("da-DK").Calendar;
            int week = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            Console.WriteLine(week);

            //var rootNode = _contentService.GetById(1057);
            var rootNode = _contentService.GetById(1089);

            var newItem = _contentService.Create(data.SelectedProjectId + "-Uge" + week + "-Svedsken", rootNode.Id, "testDocType", -1);
            newItem.SetValue("testTextString", data.SelectedProjectId);
            _contentService.Save(newItem);

            return newItem;
        }
    }
}
