using System;
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

        public T Insert(T entity) 
        {
            return this.UseDb(c =>
                {
                    if (c.FindOne(e => e.Id == entity.Id) != null)
                        throw new ArgumentException("Id of this entity is not unique");

                    return c.FindOne(e => e.Id == (Guid)c.Insert(entity));
                });
        }

        public T Update(T entity)
        {
            return this.UseDb(c =>
            {
                if (c.FindOne(e => e.Id == entity.Id) == null)
                    throw new ArgumentException("Entity with this id does not exist.");

                return c.FindOne(e => e.Id == (Guid)c.Insert(entity));
            });
        }

        public void Delete(T entity) =>
            this.UseDb<bool>(c => c.Delete(new BsonValue(entity.Id)));
        
        private TReturn UseDb<TReturn>(Func<ILiteCollection<T>, TReturn> a)
        {
            using(var db = new LiteDatabase(DatabaseName))
            {
                return a(db.GetCollection<T>(this.CollectionName));
            }
        }
    }
}
