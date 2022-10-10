using BBS.Common;
using BBS.Model.Enum;

using Microsoft.AspNetCore.Mvc;

namespace BBS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("/Login")]
        public string Login()
        {
            return ResponCode.Success.ToAck(null);
        }
    }
}
