using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQLDataAccess.Mapping
{
    public class AccountMap
    {
        public static void Map(EntityTypeConfiguration<Account> config)
        {
            config.HasKey(m => m.Id);

            config.Property(m => m.Name).HasColumnType("varchar").HasColumnName("Name").IsRequired();

            config.Property(m => m.Login).IsRequired();

            config.Property(m => m.Password).IsRequired();

            config.Property(m => m.Email).IsRequired();

            config.HasMany(m => m.Objectives);
        }
    }
}
