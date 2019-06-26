using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Stuff
{
    public interface IUnitOfWork<TEntity> where TEntity: class
    {
        IRepository<TEntity, Guid> entity { get; }
        void Save();
    }
}
