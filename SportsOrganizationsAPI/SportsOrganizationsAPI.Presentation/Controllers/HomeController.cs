using Microsoft.AspNetCore.Mvc;

namespace SportsOrganizationsAPI.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        /// <summary>
        /// ������ ���
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("HelloWorld")]
        public IActionResult HelloWorld()
        {
            return Ok();
        }
    }
}