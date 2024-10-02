using Store.MohamedBassem.Domain;
using Store.MohamedBassem.Domain.Entities;
using Store.MohamedBassem.Domain.Repositories.Contract;
using Store.MohamedBassem.Repository.Data.Contexts;
using Store.MohamedBassem.Repository.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.MohamedBassem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IGenericRepositroy<TEntity, TKey> Repositroy<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {

                var Repository = new GenericRepositroy<TEntity, TKey>(_context);
                _repositories.Add(type, Repository);
            }
              return  _repositories[type] as  IGenericRepositroy<TEntity,TKey>;
        }
    }
}
