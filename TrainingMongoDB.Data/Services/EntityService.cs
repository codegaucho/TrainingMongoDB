//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TrainingMongoDB.Data.Services
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using Entities;

    public abstract class EntityService<T> : IEntityService<T> where T : IMongoEntity
    {
        protected readonly MongoConnectionHandler<T> MongoConnectionHandler;

        public virtual void Create(T entity)
        {
            //// save the entity with safe mode
            var result = this.MongoConnectionHandler.MongoCollection.Save(
                    entity,
                    new MongoInsertOptions { 
                        WriteConcern = WriteConcern.Acknowledged
                    }
            );

            if (!result.Ok) { 
                ////something horrible went wrong
            }
        }

        public virtual void Delete(string id)
        {
            var result = this.MongoConnectionHandler.MongoCollection.Remove(
                Query<T>.EQ(e => e.Id, new ObjectId(id)),
                RemoveFlags.None,
                WriteConcern.Acknowledged
            );
            if (!result.Ok)
            {
                ////something horrible went wrong
            }
        }

        protected EntityService()
        {
            MongoConnectionHandler = new MongoConnectionHandler<T>();
        }

        public virtual T GetById(string id)
        {
            var entityQuery = Query<T>.EQ(e => e.Id, new ObjectId(id));
            return this.MongoConnectionHandler.MongoCollection.FindOne(entityQuery);
        }

        public abstract void Update(T entity);
    }
}
