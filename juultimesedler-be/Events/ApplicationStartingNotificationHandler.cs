using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Events
{
    public class ApplicationStartingNotificationHandler : INotificationHandler<UmbracoApplicationStartingNotification>
    {
        private IContentService _contentService;
        private IUserService _userService;
        private IDataTypeService _dataTypeService;

        public ApplicationStartingNotificationHandler(IContentService contentService, IUserService userService, IDataTypeService dataTypeService)
        {
            _contentService = contentService;
            _userService = userService;
            _dataTypeService = dataTypeService;
        }

        public void Handle(UmbracoApplicationStartingNotification notification)
        {
            // HACK: Populate list with users for use on projects - should use multiuser picker instead in Umbraco project content type
            IUserGroup workerGroup = _userService.GetUserGroupByAlias("workers");
            var allWorkers =_userService.GetAllInGroup(workerGroup.Id);

            // TODO
            // Add workers to list
            var workerList = _dataTypeService
                                .GetAll()
                                .Where(editor => editor.Name == "TimeSheet - Worker List");
           
        }
    }
}
