using Project.Core.Stuff;
using Project.SQLDataAccess.Entities;
using Project.SQLDataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.SQLDataAccess.Stuff
{
    public class UnitOfWork<TEntity> :IDisposable, IUnitOfWork<TEntity> where TEntity:class  
    {
        private static ProjectDbContext _context;
        private Repository<TEntity, Guid> _repo;

        public UnitOfWork() { }
        public UnitOfWork(ProjectDbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity,Guid> entity
        {
            get
            {
                if (_repo == null)
                    _repo =  new Repository<TEntity, Guid>(_context);
                return _repo;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
