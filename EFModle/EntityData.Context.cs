﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFModle
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<PROJ_PRODUCT> PROJ_PRODUCT { get; set; }
        public DbSet<T_PRODUCE_ORDER> T_PRODUCE_ORDER { get; set; }
        public DbSet<T_PRODUCE_ORDERLINE> T_PRODUCE_ORDERLINE { get; set; }
        public DbSet<T_PRODUCE_POKE> T_PRODUCE_POKE { get; set; }
        public DbSet<T_PRODUCE_SORTTROUGH> T_PRODUCE_SORTTROUGH { get; set; }
        public DbSet<T_PRODUCE_SYNSEQ> T_PRODUCE_SYNSEQ { get; set; }
        public DbSet<T_PRODUCE_TASK> T_PRODUCE_TASK { get; set; }
        public DbSet<T_PRODUCE_TASKLINE> T_PRODUCE_TASKLINE { get; set; }
        public DbSet<T_UN_POKE> T_UN_POKE { get; set; }
        public DbSet<T_UN_TASK> T_UN_TASK { get; set; }
        public DbSet<T_UN_TASKLINE> T_UN_TASKLINE { get; set; }
        public DbSet<T_WMS_ITEM> T_WMS_ITEM { get; set; }
        public DbSet<T_PACKAGE_TASK> T_PACKAGE_TASK { get; set; }
        public DbSet<T_PRODUCE_POKESEQ> T_PRODUCE_POKESEQ { get; set; }
    }
}
