﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FSLL.MS.Core.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class fsll_coreEntities : DbContext
    {
        public fsll_coreEntities()
            : base("name=fsll_coreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<userlogin> userlogins { get; set; }
        public DbSet<vmember> vmembers { get; set; }
        public DbSet<vrole> vroles { get; set; }
        public DbSet<vmemberingroup> vmemberingroups { get; set; }
        public DbSet<vgroup> vgroups { get; set; }
    }
}
