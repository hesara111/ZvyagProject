using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Stuff
{
    public class CObjective
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StatusName { get; set; }

        public int StatusID { get; set; }

        public string UserName { get; set; }
    }
}
