using Project.Core.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BuisnessLogic.Manage
{
    public interface IAccountManager<LEntity> where LEntity:class
    {
        LEntity GetAccount(LoginVm loginVm);

        bool IsExistedByName(string login);
    }
}
