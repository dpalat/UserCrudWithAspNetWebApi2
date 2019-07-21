using System;
using System.Collections.Generic;

namespace UsersCrud.Repository
{
    public interface IRepository<T> where T : ISearchable
    {
        void Delete(Guid id);

        T FindById(Guid id);

        IEnumerable<T> List();

        void Save(T item);
    }
}