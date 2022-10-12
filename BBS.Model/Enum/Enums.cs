using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Model.Enum
{
    public enum ResponCode
    {
        Success = 0,
        业务错误 = 1001,
        传参错误 = 1002,
        系统错误 = 1003,
        权限错误 = 1004,
        数据库错误 = 1005,
    }
}
