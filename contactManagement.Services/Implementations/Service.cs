using contactManagement.DAL.Interfaces;
using contactManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contactManagement.Services.Implementations
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> _repo;
        public Service(IRepository<TEntity> repo)
        {
            _repo = repo;
        }
        public void Add(TEntity entity)
        {
            _repo.Add(entity);
            _repo.SaveChanges();
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
            _repo.SaveChanges();
        }

        public TEntity Find(int Id)
        {
            return _repo.Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repo.GetAll();
        }

        public void Update(TEntity entity)
        {
            _repo.Update(entity);
            _repo.SaveChanges();
        }
    }
}
