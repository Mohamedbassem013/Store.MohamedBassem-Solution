using Store.MohamedBassem.Domain.Entities;
using Store.MohamedBassem.Domain.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.MohamedBassem.Domain
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync(); //Save Channge هتعمل 

        // Create Repository<T> And Return
        IGenericRepositroy<TEntity , TKey> Repositroy<TEntity , TKey>() where TEntity : BaseEntity<TKey>;
    }
}
