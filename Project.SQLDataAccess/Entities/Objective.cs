using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQLDataAccess.Entities
{
    public class Objective
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Name { get; set;}

        public string Description { get; set; }

        public string StatusName { get; set; }

       // public Account User { get; set; }

        public int StatusID { get; set; }

        public Guid UserID { get; set; }

    }
}
