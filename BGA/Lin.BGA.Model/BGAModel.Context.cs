﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lin.BGA.Model
{
    using System;
#pragma warning disable CS0234 // 命名空间“System.Data”中不存在类型或命名空间名“Entity”(是否缺少程序集引用?)
    using System.Data.Entity;
#pragma warning restore CS0234 // 命名空间“System.Data”中不存在类型或命名空间名“Entity”(是否缺少程序集引用?)
#pragma warning disable CS0234 // 命名空间“System.Data”中不存在类型或命名空间名“Entity”(是否缺少程序集引用?)
    using System.Data.Entity.Infrastructure;
#pragma warning restore CS0234 // 命名空间“System.Data”中不存在类型或命名空间名“Entity”(是否缺少程序集引用?)
    
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbContext”(是否缺少 using 指令或程序集引用?)
    public partial class BGAEntities : DbContext
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbContext”(是否缺少 using 指令或程序集引用?)
    {
        public BGAEntities()
            : base("name=BGAEntities")
        {
        }
    
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbModelBuilder”(是否缺少 using 指令或程序集引用?)
#pragma warning disable CS0115 // “BGAEntities.OnModelCreating(DbModelBuilder)”: 没有找到适合的方法来重写
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
#pragma warning restore CS0115 // “BGAEntities.OnModelCreating(DbModelBuilder)”: 没有找到适合的方法来重写
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbModelBuilder”(是否缺少 using 指令或程序集引用?)
        {
            throw new UnintentionalCodeFirstException();
        }
    
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
        public virtual DbSet<AppVersionInfo> AppVersionInfo { get; set; }
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
        public virtual DbSet<CategoryInfo> CategoryInfo { get; set; }
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
        public virtual DbSet<MusicInfo> MusicInfo { get; set; }
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
        public virtual DbSet<StoreInfo> StoreInfo { get; set; }
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
        public virtual DbSet<ProfilesInfo> ProfilesInfo { get; set; }
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
#pragma warning disable CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
        public virtual DbSet<MusicLogInfo> MusicLogInfo { get; set; }
#pragma warning restore CS0246 // 未能找到类型或命名空间名“DbSet<>”(是否缺少 using 指令或程序集引用?)
    }
}
