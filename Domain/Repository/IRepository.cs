using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {

        T Insert(T item);
        T Update(T item);
        bool Delete(Guid id);
        T Select(Guid id);
        IEnumerable<T> Select();
        bool Exist(Guid id);
        bool Exist(Func<T,bool> filtro);
        IEnumerable<T> SelectWithFilter(Func<T, bool> filtro);
    }
}
