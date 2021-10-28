using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly CofrinhoContext _context;
        private DbSet<T> _dataSet;

        public BaseRepository(CofrinhoContext context)
        {
            _context = context;
            _dataSet = context.Set<T>();
        }

        public bool Delete(Guid Id)
        {
            try
            {
                bool ret = true;
                var result =  _dataSet
                    .SingleOrDefault(p => p.Id.Equals(Id));

                if (result == null)
                    return ret;

                _dataSet.Remove(result);
                 _context.SaveChanges();

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T Insert(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }
                item.CreateAt = DateTime.UtcNow;
                _dataSet.Add(item);

                 _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public bool Exist(Guid id)
        {
            return _dataSet.Any(p => p.Id.Equals(id));
        }

        public T Select(Guid id)
        {
            try
            {
                return  _dataSet.SingleOrDefault(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> Select()
        {
            try
            {
                return  _dataSet.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public T Update(T item)
        {
            try
            {
                var result = _dataSet
                    .SingleOrDefault(p => p.Id.Equals(item.Id));

                if (result == null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public IEnumerable<T> SelectWithFilter(Func<T, bool> filtro)
        {
            return _dataSet.Where(filtro);
        }

        public bool Exist(Func<T, bool> filtro)
        {
            return _dataSet.Any(filtro);
        }

    }
}
