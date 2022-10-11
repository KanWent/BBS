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
            Logger.Info("进入登录接口");
            return ResponCode.Success.ToAck(null);
        }
    }
}
