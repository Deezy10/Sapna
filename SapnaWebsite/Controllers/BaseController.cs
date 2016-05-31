using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SapnaWebsite.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {
        
    }
}