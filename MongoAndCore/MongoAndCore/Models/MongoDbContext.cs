using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MongoAndCore.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _mongoDb;
        public MongoDbContext()
        {
            string ConnString = "mongodb://localhost:27017/";
            string db = "MongoCRUDdb";
            var client = new MongoClient(ConnString);
            _mongoDb = client.GetDatabase(db);
        }
        public IMongoCollection<Student> Student
        {
            get
            {
                return _mongoDb.GetCollection<Student>("Student");
            }
        }
    }
}
