using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LiteDB;

namespace KawaiiMoneyManager.Data.LiteDb
{
    public class LiteDbDataService<T> : IDataService<T>
        where T : INamedEntity
    {
        private readonly string DatabaseName;

        private readonly string CollectionName = typeof(T).Name;

        public LiteDbDataService(string connection = null) => 
            DatabaseName = connection ?? "KawaiiMoneyManager.db";

        public T Get(Guid id)
            => this.UseDb(c => c.FindOne(e => e.Id == id));

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null) =>
            this.UseDb(c => (predicate == null ? c.FindAll() : c.Find(predicate)).ToList());

        public T Insert(T entity) => 
            this.UseDb(c => c.FindOne(e => e.Id == (Guid)c.Insert(entity)));

        public T Update(T entity) =>       
            this.UseDb(c => !c.Update(entity)
                ? throw new ArgumentException("Entity cannot be updated because it does not exist")
                : c.FindOne(e => e.Id == entity.Id));

        public void Delete(T entity) =>
            this.UseDb<bool>(c => c.Delete(new BsonValue(entity.Id)));

        public void DeleteAll() =>
            this.UseDb(c => c.DeleteAll());
        
        private TReturn UseDb<TReturn>(Func<ILiteCollection<T>, TReturn> a)
        {
            using(var db = new LiteDatabase(DatabaseName))
            {
                return a(db.GetCollection<T>(this.CollectionName));
            }
        }
    }
}
