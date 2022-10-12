using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Model.ApiEntiy
{
    /// <summary>
    /// 文章实体
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string? Context { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 文章封面
        /// </summary>
        public string? Img { get; set; }
        /// <summary>
        /// 文章类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remake { get; set; }
    }
}
