using System;
using System.Collections.Generic;

namespace BBS.Model.DBEntity
{
    /// <summary>
    /// 文章表
    /// </summary>
    public partial class Article
    {
        /// <summary>
        /// 文章ID 主键
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 文章内容
        /// </summary>
        public string Context { get; set; } = null!;
        /// <summary>
        /// 文章标题
        /// </summary>
        public string Title { get; set; } = null!;
        /// <summary>
        /// 文章封面
        /// </summary>
        public string Img { get; set; } = null!;
        /// <summary>
        /// 文章类型
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string? OperCode { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remake { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>
        public string? UserCode { get; set; }
    }
}
