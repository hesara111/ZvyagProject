using Project.Core.Stuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BuisnessLogic.Manage
{
    public class Manager<TEntity, TId> : IManager<TEntity, TId> where TEntity : class
    {
        private readonly IUnitOfWork<TEntity> utf;

        public Manager()
        {

        }
        public Manager(IUnitOfWork<TEntity> repo)
        {
            utf = repo;
        }


        public void Create(TEntity model)
        {
            utf.entity.Create(model);
            utf.Save();
        }

        public void Delete(Guid id)
        {
            utf.entity.Delete(id);
            utf.Save();
        }

        public void Edit(TEntity model, Guid id)
        {
            utf.entity.Edit(model, id);
            utf.Save();
        }

        public TEntity Get(Guid id)
        {
            return utf.entity.Get(id);
        }

        public List<TEntity> GetAll()
        {
            return utf.entity.GetAll();
        }
    }
}
