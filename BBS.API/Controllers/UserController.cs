using BBS.Common;
using BBS.Model.Enum;

using Microsoft.AspNetCore.Mvc;

namespace BBS.API.Controllers
{
    /// <summary>
    /// 用户API
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[Action]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        ///  用户登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionName("Login")]
        public string Login()
        {
            Logger.Info("进入登录接口");
            return ResponCode.Success.ToAck(null);
        }
    }
}
