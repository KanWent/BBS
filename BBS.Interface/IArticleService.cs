using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Interface
{
    public interface IArticleService
    {

        int AddArticle(BBS.Model.ApiEntiy.Article Info, ref string ErrMsg);
        int DeleteArticle(BBS.Model.ApiEntiy.Article Info, ref string ErrMsg);
        int GetArticleList(ref List<BBS.Model.ApiEntiy.Article> articles,ref string ErrMsg);


    }
}
