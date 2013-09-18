//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace TrainingMongoDB.Data
{
    using Entities;
    using MongoDB.Driver;

    public class MongoConnectionHandler<T> where T : IMongoEntity
    {
        public MongoCollection<T> MongoCollection { get; set; }

        public MongoConnectionHandler()
        {
            const string connectionString = "mongodb://localhost";
            const string databaseName = "training";

            var mongoClient = new MongoClient(connectionString);
            var mongoServer = mongoClient.GetServer();
            var db = mongoServer.GetDatabase(databaseName);

            MongoCollection = db.GetCollection<T>(typeof(T).Name.ToLower() + "s");
            
        }
    }
}
