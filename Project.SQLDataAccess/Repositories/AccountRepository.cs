using Project.Core.Stuff;
using Project.SQLDataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQLDataAccess.Repositories
{
    public class AccountRepository<LEntity>:IAccountRepository<LEntity> where LEntity: Account
    {
        ProjectDbContext _context;
        DbSet<LEntity> _dbSet;

        public AccountRepository()
        {

        }

        public AccountRepository(ProjectDbContext context)
        {
            _context = context;
            _dbSet = context.Set<LEntity>();
        }

        public LEntity GetAccount(LoginVm loginVm)
        {
            return _dbSet.Where(a => a.Login == loginVm.Login
                     && a.Password == loginVm.Password).FirstOrDefault();
        }

        public bool IsExistedByName(string login)
        {
            return _dbSet.Any(a => a.Login == login);
            
        }

        public void EmailConfirm(Guid id)
        {
            var mode = _context.Users.Find(id);
            var model = mode;
            model.IsVerified = true;
            _context.Entry(mode).CurrentValues.SetValues(model);
            _context.SaveChanges();
        }


    }
}
