using Project.SQLDataAccess.Entities;
using Project.SQLDataAccess.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQLDataAccess
{
    public class ProjectDbContext:DbContext
    {
       

        public ProjectDbContext()
           : base("ProjectDbContext")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            AccountMap.Map(modelBuilder.Entity<Account>());
            PermissionMap.Map(modelBuilder.Entity<Permission>());
            ObjectiveMap.Map(modelBuilder.Entity<Objective>());
            StatusMap.Map(modelBuilder.Entity<Status>());
        }
        public virtual DbSet<Account> Users { get; set; }
        public virtual DbSet<Objective> Objectives { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }


    }
}
