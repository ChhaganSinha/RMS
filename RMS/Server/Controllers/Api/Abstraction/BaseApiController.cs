using Microsoft.AspNetCore.Mvc;

namespace RMS.Server.Controllers.Api.Abstraction
{
    public class BaseApiController : ControllerBase
    {
        public BaseApiController(ILogger logger) : base()
        {
            Logger = logger;
        }

        public ILogger Logger { get; }
    }

}
