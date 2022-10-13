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
                msg = Message,
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
        public static string ToAck(this ResponCode code, object o, string Message = "")
        {

            BaseResponse<object> baseResponse = new BaseResponse<object>()
            {
                code = (int)code,
                msg = Message,
                data = o
            };
            return JsonConvert.SerializeObject(baseResponse);
        }
        /// <summary>
        /// 同名映射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T MapperEntity<T>(this object o)
        {
            try
            {
                Type old = o.GetType();
                Type newType = typeof(T);
                object a = Activator.CreateInstance(newType);   //创建对象
                var allPrpo = old.GetProperties();
                var newPrpo = newType.GetProperties();
                if (allPrpo != null)
                {
                    foreach (var item in allPrpo)
                    {
                        var pro = newPrpo.Where(x => x.Name.ToUpper() == item.Name.ToUpper()).FirstOrDefault();
                        if (pro is null )
                        {
                            continue;
                        }
                        pro.SetValue(a, item.GetValue(o));
                    }
                }
                return (T)a;
            }
            catch (Exception)
            {
                return default;
            }

        }
        /// <summary>
        /// 序列化JSON
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o);
        }
        /// <summary>
        /// 反序列化JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static T Json2Entity<T>(this string o)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(o);
            }
            catch (Exception ex)
            {
                return default;
            }
        }

    }
}