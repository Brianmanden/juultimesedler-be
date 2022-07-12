using Microsoft.AspNetCore.Mvc;
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
        public object Index([FromBody] object data)
        {
            var bp = "";
            var rootNode = _contentService.GetById(1057);
            var newItem = _contentService.CreateAndSave("testCreate" + DateTime.Now.ToShortTimeString(), rootNode.Id, "testDocType", -1);

            object returnObj = new { 
                theId = newItem.Id,
                thing = newItem.Name,
            };

            return returnObj;
        }
    }
}
