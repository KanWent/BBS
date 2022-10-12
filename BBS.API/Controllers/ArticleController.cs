using System.Collections.Generic;
using System.Configuration;

using BBS.Commom.MEF.Base;
using BBS.Common;
using BBS.Model.Enum;

using Microsoft.AspNetCore.Mvc;

namespace BBS.API.Controllers
{
    /// <summary>
    /// 文章相关API
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {


        private readonly IConfiguration Configuration;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configuration"></param>
        public ArticleController(IConfiguration configuration) => Configuration = configuration;

        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/GetALL")]
        public string GetArticleList()
        {
            Logger.Info("进入获取文章列表接口");
            if (InterFaceList.IArticleServicesList is null)
            {
                Logger.Info("MEF注入失败！");
                return ResponCode.系统错误.ToAck(Message: "MEF注入失败");
            }
            var articleServiceName = Configuration["InterfaceConfig:ArticleService"];
            Logger.Info("articleServiceName:" + articleServiceName);
            var articleService = InterFaceList.IArticleServicesList.Where(x => x.Metadata.Name == articleServiceName).FirstOrDefault();
            if (articleService is null)
            {
                Logger.Info("MEF注入寻找配置失败，请检查配置！");
                return ResponCode.系统错误.ToAck(Message: "MEF注入寻找配置失败，请检查配置！");
            }
            string ErrMsg = String.Empty;
            List<Model.ApiEntiy.Article> articles = new List<Model.ApiEntiy.Article>();
            var retCode = articleService.Value.GetArticleList(ref articles, ref ErrMsg);
            if (retCode == (int)ResponCode.Success)
            {
                Logger.Info("List:" + articles.ToJson());
                return articles.ToAck(Message: ErrMsg);
            }
            return ((ResponCode)retCode).ToAck(Message: ErrMsg);


        }
        /// <summary>
        /// 新增文章接口
        /// </summary>
        /// <param name="InJson"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Insert")]
        public string AddArticle([FromBody] string InJson)
        {

            Logger.Info("进入添加文章列表接口");
            if (InterFaceList.IArticleServicesList is null)
            {
                Logger.Info("MEF注入失败！");
                return ResponCode.系统错误.ToAck(Message: "MEF注入失败");
            }
            var articleServiceName = Configuration["InterfaceConfig:ArticleService"];
            Logger.Info("articleServiceName:" + articleServiceName);
            var articleService = InterFaceList.IArticleServicesList.Where(x => x.Metadata.Name == articleServiceName).FirstOrDefault();
            if (articleService is null)
            {
                Logger.Info("MEF注入寻找配置失败，请检查配置！");
                return ResponCode.系统错误.ToAck(Message: "MEF注入寻找配置失败，请检查配置！");
            }
            string ErrMsg = String.Empty;
            var article = InJson.Json2Entity<Model.ApiEntiy.Article>();
            if (article is null)
            {
                Logger.Info("序列化失败！");
                return ResponCode.传参错误.ToAck(Message: "参数有误，序列化失败");
            }
            var retCode = articleService.Value.AddArticle(article, ref ErrMsg);
            ResponCode code = (ResponCode)retCode;
            return code.ToAck(Message: ErrMsg);
        }

    }
}
