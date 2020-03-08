using iXOnlineWeb.Data.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iXOnlineWeb.Core.BusinessLogic
{
    public class CRUDRepository<T> where T : class
    {
        private iXOnlineWebEntities _dbContext = null;
        private DbSet<T> Dataset = null;

        public CRUDRepository()
        {
            this._dbContext = new iXOnlineWebEntities();
            Dataset = _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Dataset.ToList().AsQueryable();
        }

        public T GetById(object Id)
        {
            return Dataset.Find(Id);
        }

        public void Insert(T GenericObject)
        {
            Dataset.Add(GenericObject);
        }

        public void Update(T GenericObject)
        {
            Dataset.Attach(GenericObject);
            _dbContext.Entry(GenericObject).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            T ExistingObject = Dataset.Find(Id);
            Dataset.Remove(ExistingObject);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

    }
}
