using contactManagement.DAL.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace contactManagement.DAL.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private static string _filePath = @"SeedData\contacts.json";

        private static List<TEntity> _entities = new List<TEntity>();
        public Repository()
        {
        }

        static Repository()
        {
            // Seed data from JSON file
            var contactsJson = File.ReadAllText(_filePath);
            _entities = JsonConvert.DeserializeObject<List<TEntity>>(contactsJson);
        }
        public void Add(TEntity entity)
        {
            int maxId = _entities.Max(e => (int)e.GetType().GetProperty("Id").GetValue(e));

            // Get the property info using reflection
            var property = typeof(TEntity).GetProperty("Id", BindingFlags.Public | BindingFlags.Instance);

            if (property != null && property.CanWrite) // Ensure the property is writable
            {
                // Set the value of the property
                property.SetValue(entity, Convert.ChangeType(maxId+1, property.PropertyType));
            }
            _entities.Add(entity);
        }

        public void Delete(int Id)
        {
            var entity = _entities.FirstOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == Id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }

        }

        public TEntity Find(int Id)
        {
            return _entities.FirstOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities;
        }
        public void Update(TEntity entity)
        {
            var entityId = (int)entity.GetType().GetProperty("Id").GetValue(entity);
            var existingEntity = _entities.FirstOrDefault(e => (int)e.GetType().GetProperty("Id").GetValue(e) == entityId);

            if (existingEntity != null)
            {
                _entities.Remove(existingEntity);
                _entities.Add(entity);
            }

        }
        public void SaveChanges()
        {
            var json = JsonConvert.SerializeObject(_entities);
            File.WriteAllText(_filePath, json);
        }
    }
}
