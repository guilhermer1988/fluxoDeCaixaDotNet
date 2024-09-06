using Microsoft.EntityFrameworkCore;
using FluxoCaixa.Domain;
using FluxoCaixa.Infra.Data.Context;
using FluxoCaixa.Infra.Interface;

namespace FluxoCaixa.Infra
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _context { get; private set; }
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void DiscardAllChanges()
        {
            foreach (var entry in _context.ChangeTracker.Entries().Where(x => x.State != EntityState.Unchanged).ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        public virtual async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public virtual async Task Insert(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
        }

        public virtual async Task<Boolean> InsertAndSave(T obj)
        {
            await _context.Set<T>().AddAsync(obj);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<Boolean> InsertMany(IEnumerable<T> objs)
        {
            await _context.Set<T>().AddRangeAsync(objs);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual void Update(T obj)
        {
            _context.Update(obj);
        }

        public virtual async Task<Boolean> UpdateAndSave(T obj)
        {
            _context.Update(obj);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> UpdateMany(IEnumerable<T> objs)
        {
            _context.UpdateRange(objs);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<Boolean> Delete(int id)
        {
            _context.Set<T>().Remove(await Select(id));
            return await _context.SaveChangesAsync() > 0;
        }
        public virtual async Task<Boolean> DeleteMany(IEnumerable<T> objs)
        {
            _context.Set<T>().RemoveRange(objs);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<IEnumerable<T>> Select()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> Select(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetBy(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
