using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BBS.Model.DBEntity
{
    public partial class bbsContext : DbContext
    {
        public bbsContext()
        {
        }

        public bbsContext(DbContextOptions<bbsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<SysRole> SysRoles { get; set; } = null!;
        public virtual DbSet<SysUser> SysUsers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;user id=root;password=123456;database=bbs", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("article");

                entity.HasComment("文章表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasMaxLength(200)
                    .HasComment("文章ID 主键");

                entity.Property(e => e.Context).HasComment("文章内容");

                entity.Property(e => e.Img)
                    .HasMaxLength(2000)
                    .HasComment("文章封面");

                entity.Property(e => e.OperCode)
                    .HasMaxLength(45)
                    .HasComment("操作员");

                entity.Property(e => e.OperDate)
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.Remake)
                    .HasMaxLength(2000)
                    .HasComment("备注");

                entity.Property(e => e.Title)
                    .HasMaxLength(2000)
                    .HasComment("文章标题");

                entity.Property(e => e.Type)
                    .HasColumnType("int(11)")
                    .HasComment("文章类型");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(255)
                    .HasComment("作者ID");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.RoleCode)
                    .HasName("PRIMARY");

                entity.ToTable("sys_role");

                entity.HasComment("角色表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(100)
                    .HasComment("角色编码");

                entity.Property(e => e.FunctionCode)
                    .HasMaxLength(45)
                    .HasComment("功能编码");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasComment("最后登录时间");

                entity.Property(e => e.OperCode)
                    .HasMaxLength(45)
                    .HasComment("操作员");

                entity.Property(e => e.OperDate)
                    .HasColumnType("datetime")
                    .HasComment("操作时间");

                entity.Property(e => e.Remake)
                    .HasMaxLength(2000)
                    .HasComment("备注");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(45)
                    .HasComment("角色名称");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasComment("用户状态0->未激活1->已激活");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.ToTable("sys_user");

                entity.HasComment("用户表")
                    .HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasComment("自增主键");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasComment("最后登录时间");

                entity.Property(e => e.Remake)
                    .HasMaxLength(2000)
                    .HasComment("备注");

                entity.Property(e => e.RoleCode)
                    .HasMaxLength(45)
                    .HasComment("角色编码 |分割");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasComment("用户状态0->未激活1->已激活");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(100)
                    .HasComment("用户编号");

                entity.Property(e => e.UserName)
                    .HasMaxLength(45)
                    .HasComment("用户名");

                entity.Property(e => e.UserPass)
                    .HasMaxLength(45)
                    .HasComment("用户密码");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
