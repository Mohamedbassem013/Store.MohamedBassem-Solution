using Microsoft.EntityFrameworkCore;
using Store.MohamedBassem.Domain.Entities;
using Store.MohamedBassem.Domain.Repositories.Contract;
using Store.MohamedBassem.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.MohamedBassem.Repository.Repositories
{
    public class GenericRepositroy<TEntity, TKey> : IGenericRepositroy<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _context;

        public GenericRepositroy(StoreDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return (IEnumerable <TEntity> )await _context.Products.Include(p=>p.Brand).Include(p=>p.type).ToListAsync();
            }
         return  await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetAsync(TKey id)
        {
            if (typeof(TEntity) == typeof(Product))
            {
                return await _context.Products.Include(p => p.Brand).Include(p => p.type).FirstOrDefaultAsync(P=>P.Id == id as int?) as TEntity;
            }
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
           await _context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Delete(TEntity entity)
        {
             _context.Remove(entity);
        }
    }
}
