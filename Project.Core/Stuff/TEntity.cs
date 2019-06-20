using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Stuff
{
    class TEntity<TID>where TID:class
    {
        TID Id { get; set; }
    }
}
