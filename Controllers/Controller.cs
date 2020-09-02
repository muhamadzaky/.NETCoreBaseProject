using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Emveep.TalentHunter.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class Controller : ControllerBase
    {
        [HttpGet]
        public ContentResult Get()
        {
            return new ContentResult {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<html><header><title>Welcome! - Emveep Talent Hunter API</title></header><body><h1>Congratulations! You connected to this API.</h1></body></html>"
            };
        }    
    }
}