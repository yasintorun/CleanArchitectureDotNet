using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Domain.Database.EFCore
{
    public class EFCoreBaseRepository<TEntity, TContext> : IRepository<TEntity> where TEntity : class, new() where TContext : DbContext, new()
    {
        private readonly TContext _context;

        public EFCoreBaseRepository()
        {
            _context = new TContext();
        }

        public TEntity Add(TEntity entity)
        {
            var _entity = _context.Entry(entity);
            _entity.State = EntityState.Added;
            _context.SaveChanges();
            return _entity.Entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {

            var _entity = _context.Entry(entity);
            _entity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return _entity.Entity;
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                var _entity = _context.Entry(entity);
                _entity.State = EntityState.Deleted;
                _context.SaveChanges();
            } catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                var _entity = _context.Entry(entity);
                _entity.State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>>? predicate)
        {
            return predicate == null
                    ? _context.Set<TEntity>().AsNoTracking().ToList()
                    : _context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? predicate)
        {

            return predicate == null
                    ? await _context.Set<TEntity>().AsNoTracking().ToListAsync()
                    : await _context.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public bool IsExists(Expression<Func<TEntity, bool>> predicate)
        {
            var isExists = _context.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate);
            
            return isExists != null;
        }

        public async Task<TEntity> UdateAsync(TEntity entity)
        {

            var _entity = _context.Entry(entity);
            _entity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return _entity.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var _entity = _context.Entry(entity);
            _entity.State = EntityState.Deleted;
            _context.SaveChanges();

            return _entity.Entity;
        }
    }
}
