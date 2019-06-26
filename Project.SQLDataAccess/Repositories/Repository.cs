using Project.Core.Stuff;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Project.SQLDataAccess.Repositories
{
    public class Repository<TEntity,TID>:IRepository<TEntity,TID> where TEntity :class
    {
        static ProjectDbContext context = new ProjectDbContext();
        DbSet<TEntity> _dbSet;
        public Repository()
        {

        }

        public Repository(ProjectDbContext Context)
        {
            context = Context;
            _dbSet = context.Set<TEntity>();
        }

       

        public void Create(TEntity model)
        {
            _dbSet.Add(model);
          //  context.SaveChanges();
        }

        public void Delete(TID id)
        {
            var model = _dbSet.Find(id);
            _dbSet.Remove(model);
            //context.SaveChanges();
        }

        public void Edit(TEntity model, TID id)
        {
            var mode = _dbSet.Find(id);
            if (mode == null)
            {
                return;
            }
            context.Entry(mode).CurrentValues.SetValues(model);
           // context.SaveChanges();
        }
        

        public TEntity Get(TID id)
        {
            
            return _dbSet.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }   
    }
}
