using Microsoft.AspNetCore.Mvc;
using RC.Weather.Api.Filters;

namespace RC.Weather.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [BadRequestsHandler]
    public abstract class ApplicationBaseController : ControllerBase
    {
    }
}