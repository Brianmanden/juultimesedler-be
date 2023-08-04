using juultimesedler_be.Interfaces;
using Umbraco.Cms.Core.Services;

namespace juultimesedler_be.Services;

public class WorkersService : IWorkersService
{
    private IUserService _userService;
    private IContentService _contentService;

    public WorkersService(IUserService userService, IContentService contentService)
    {
        _userService = userService;
        _contentService = contentService;
    }

    public string GetWorkerKey(int workerId)
    {
        string parsedWorkerKey = _contentService.GetById(workerId)?.Key.ToString().Replace("-", "");
        return parsedWorkerKey;
    }
}
