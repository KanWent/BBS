using System;
using System.Collections.Generic;

namespace BBS.Model.DBEntity
{
    /// <summary>
    /// 用户表
    /// </summary>
    public partial class SysUser
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public string Id { get; set; } = null!;
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = null!;
        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserCode { get; set; } = null!;
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass { get; set; } = null!;
        /// <summary>
        /// 角色编码 |分割
        /// </summary>
        public string? RoleCode { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLogin { get; set; }
        /// <summary>
        /// 用户状态0-&gt;未激活1-&gt;已激活
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Remake { get; set; }
    }
}
