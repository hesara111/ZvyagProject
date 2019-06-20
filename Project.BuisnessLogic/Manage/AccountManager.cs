using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Core.Stuff;

namespace Project.BuisnessLogic.Manage
{
    public class AccountManager<LEntity>:IAccountManager<LEntity> where LEntity:class
    {
        private readonly IAccountRepository<LEntity> _repo;

        public AccountManager()
        {

        }

        public AccountManager(IAccountRepository<LEntity> repo)
        {
            _repo = repo;
        }

        public LEntity GetAccount(LoginVm loginVm)
        {
            return _repo.GetAccount(loginVm);
        }

        public bool IsExistedByName(string login)
        {
            return _repo.IsExistedByName(login);
        }

        
    }
}
