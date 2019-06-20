using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQLDataAccess.Mapping
{
    public class ObjectiveMap
    {
        public static void Map(EntityTypeConfiguration<Objective> config)
        {
            config.HasKey(m => m.Id);

            config.Property(m => m.Name).HasColumnType("varchar").HasColumnName("Name").IsRequired();

            config.Property(m => m.StatusID).IsRequired();

            config.Property(m => m.UserID).IsRequired();
        }
    }
}
