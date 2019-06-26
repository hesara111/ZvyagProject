using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BuisnessLogic.Manage
{
    public interface IManager<TEntity, TId> where TEntity : class
    {
        List<TEntity> GetAll();
        TEntity Get(Guid id);
        void Create(TEntity model);
        void Edit(TEntity model, Guid id);
        void Delete(Guid id);
    }
}
