﻿using LMS.Core.Domain.Models;
using LMS.Core.Infrastructure.Database.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace LMS.Core.Infrastructure.Database.EntityFramework
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : Entity where TContext : DbContext
    {
        private readonly TContext _context;

        public EfRepository(TContext context)
        {
            _context = context;
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate)
        {
            var list = _context.Set<TEntity>();
            return predicate == null ? list : list.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetListAysnc(Expression<Func<TEntity, bool>>? predicate)
        {
            var list = _context.Set<TEntity>().AsNoTracking();
            return await (predicate == null ? list.ToListAsync() : list.Where(predicate).ToListAsync());
        }
        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
