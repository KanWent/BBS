using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BBS.Interface;
using BBS.Model.ApiEntiy;
using BBS.Model;
using BBS.Common;
using BBS.Model.DBEntity;
using BBS.Model.Enum;
using System.ComponentModel.Composition;

namespace BBS.Services
{
    [Export(typeof(IArticleService))]
    [ExportMetadata("Name", "ArticleService")]
    public class ArticleService : IArticleService
    {
        public int AddArticle(Model.ApiEntiy.Article Info, ref string ErrMsg)
        {
            var article = Info.MapperEntity<BBS.Model.DBEntity.Article>();
            if (article is null)
            {
                ErrMsg = "映射失败";
                return (int)ResponCode.传参错误;
            }
            int effRow = 0;
            try
            {
                article.Id = Guid.NewGuid().ToString().Replace("-", "");
                article.UserCode = "CSAPI";
                article.OperCode = "CSAPI";
                article.OperDate = DateTime.Now;
                using (var dbContext = new bbsContext())
                {
                    dbContext.Add(article);
                    effRow = dbContext.SaveChanges();
                }
                if (effRow > 0)
                {
                    effRow = (int)ResponCode.Success;
                }
                else
                {
                    ErrMsg = "添加失败";
                    effRow = (int)ResponCode.业务错误;
                }
            }
            catch (Exception ex)
            {
                effRow = (int)ResponCode.数据库错误;
            }
            return effRow;
        }

        public int DeleteArticle(Model.ApiEntiy.Article Info, ref string ErrMsg)
        {
            if (string.IsNullOrEmpty(Info.Id))
            {
                ErrMsg = "ID不能为空";
                return (int)ResponCode.传参错误;
            }
            int effRow = 0;
            try
            {
                using (var dbContext = new bbsContext())
                {

                    var article = dbContext.Articles.Where(x => x.Id == Info.Id).FirstOrDefault();
                    dbContext.Remove(article);
                    effRow = dbContext.SaveChanges();
                }
                if (effRow > 0)
                {
                    effRow = (int)ResponCode.Success;
                }
                else
                {
                    ErrMsg = "删除失败";
                    effRow = (int)ResponCode.业务错误;

                }
            }
            catch (Exception ex)
            {
                effRow = (int)ResponCode.数据库错误;
            }
            return effRow;
        }

        public int GetArticleList(ref List<Model.ApiEntiy.Article> articles, ref string ErrMsg)
        {

            try
            {
                using (var dbContext = new bbsContext())
                {
                    articles = dbContext.Articles.AsQueryable().Select(x => x.MapperEntity<Model.ApiEntiy.Article>()).ToList();
                }
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
                if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    ErrMsg = ex.InnerException.Message;
                    return (int)ResponCode.数据库错误;
                }
                return (int)ResponCode.业务错误;
            }
            return (int)ResponCode.Success;
        }
    }
}
