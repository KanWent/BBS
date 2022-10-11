using System;
using System.Collections.Generic;

namespace BBS.Model.DBEntity
{
    /// <summary>
    /// 角色表
    /// </summary>
    public partial class SysRole
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; } = null!;
        /// <summary>
        /// 角色编码
        /// </summary>
        public string RoleCode { get; set; } = null!;
        /// <summary>
        /// 功能编码
        /// </summary>
        public string FunctionCode { get; set; } = null!;
        /// <summary>
        /// 操作员
        /// </summary>
        public string? OperCode { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate { get; set; }
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
