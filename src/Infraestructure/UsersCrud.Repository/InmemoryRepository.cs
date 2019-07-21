using System;
using System.Collections.Generic;
using System.Linq;

namespace UsersCrud.Repository
{
    public class InMemoryRepository<T> : IRepository<T> where T : ISearchable
    {
        private List<T> _store;

        public InMemoryRepository()
        {
            _store = new List<T>();
        }

        public IEnumerable<T> List()
        {
            return _store;
        }

        public void Save(T item)
        {
            if (_store.Any(e => e.Equals(item)))
                Delete(item.Id);

            _store.Add(item);
        }

        public void Delete(Guid id)
        {
            _store.RemoveAll(e => e.Id == id);
        }

        public T FindById(Guid id)
        {
            return _store.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}