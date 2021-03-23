
using Microsoft.AspNetCore.Mvc;

namespace MoviesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class AbstractAPIController : ControllerBase
    {
    }
}
