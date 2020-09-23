using System;

namespace KawaiiMoneyManager.Data
{
    public interface IDataService<T>
        where T : INamedEntity
    {
        T Get(Guid id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
