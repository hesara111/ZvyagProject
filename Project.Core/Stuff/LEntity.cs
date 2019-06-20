using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Stuff
{
    public class LEntity<T>where T:class 
    {
        T Login { get; set; }
        T Password { get; set; }
    }
}
