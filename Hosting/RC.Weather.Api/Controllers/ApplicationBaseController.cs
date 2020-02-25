using Microsoft.AspNetCore.Mvc;

namespace RC.Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApplicationBaseController : ControllerBase
    {
    }
}