﻿using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<bool> DeleteAsync(Guid Id)
        {
            try
            {
                bool ret = true;
                var result = await _dataSet
                    .SingleOrDefaultAsync(p => p.Id.Equals(Id));

                if (result == null)
                    return ret;

                _dataSet.Remove(result);
                await _context.SaveChangesAsync();

                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                if (item.Id == Guid.Empty)
                {
                    item.Id = Guid.NewGuid();
                }
                item.CreateAt = DateTime.UtcNow;
                _dataSet.Add(item);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataSet.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            try
            {
                return await _dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            try
            {
                return await _dataSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> UpdateAsync(T item)
        {
            try
            {
                var result = await _dataSet
                    .SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                if (result == null)
                    return null;

                item.UpdateAt = DateTime.UtcNow;
                item.CreateAt = result.CreateAt;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }

        Task<T> IRepository<T>.InsertAsync(T item)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.UpdateAsync(T item)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository<T>.SelectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository<T>.SelectAsync()
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository<T>.ExistAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
