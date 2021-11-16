using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StorageSystem.Common;

namespace StorageSystem.Areas.Administration.Controllers
{
    [Area(GlobalConstants.AdministrationArea)]
    [Authorize(Roles =GlobalConstants.Roles.Admninistrator)]
    public class AdministrationBaseController : Controller
    {
    }
}
