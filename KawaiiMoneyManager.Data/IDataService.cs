using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KawaiiMoneyManager.Data
{
    public interface IDataService<T>
        where T : INamedEntity
    {
        T Get(Guid id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
