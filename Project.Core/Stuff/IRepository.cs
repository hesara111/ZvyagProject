using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Stuff
{
    public interface IRepository<TEntity,TID> where TEntity: class
    {
        List<TEntity> GetAll();
        TEntity Get(TID id);
        void Create(TEntity model);
        void Edit(TEntity model, TID id);
        void Delete(TID id);
    }
}
