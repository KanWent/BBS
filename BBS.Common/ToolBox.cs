using System.Dynamic;

using BBS.Model.ApiEntiy;
using BBS.Model.Enum;

using Newtonsoft.Json;

namespace BBS.Common
{
    /// <summary>
    /// 扩展方法实现类
    /// </summary>
    public static class ToolBox
    {
        /// <summary>
        /// 制造错误返回出参
        /// </summary>
        /// <param name="ex">错误对象</param>
        /// <returns></returns>
        public static string ToAck(this Exception ex)
        {
            BaseResponse<object> baseResponse = new BaseResponse<object>()
            {
                code = (int)ResponCode.系统错误,
                msg = ex.Message
            };
            return JsonConvert.SerializeObject(baseResponse);
        }

        /// <summary>
        /// 制造返回出参
        /// </summary>
        /// <param name="o">出参实体对象</param>
        /// <param name="code">返回Code</param>
        /// <param name="Message">返回信息</param>
        /// <returns></returns>
        public static string ToAck(this object o, ResponCode code = ResponCode.Success, string Message = "")
        {
            BaseResponse<object> baseResponse = new BaseResponse<object>()
            {
                code = (int)code,
                msg = String.Empty,
                data = o
            };
            return JsonConvert.SerializeObject(baseResponse);
        }
        /// <summary>
        /// 制造返回出参
        /// </summary>
        /// <param name="o">出参实体对象</param>
        /// <param name="code">返回Code</param>
        /// <param name="Message">返回信息</param>
        /// <returns></returns>
        public static string ToAck(this ResponCode code, object o  , string Message = "")
        {
            
            BaseResponse<object> baseResponse = new BaseResponse<object>()
            {
                code = (int)code,
                msg = String.Empty,
                data = o
            };
            return JsonConvert.SerializeObject(baseResponse);
        }


    }
}