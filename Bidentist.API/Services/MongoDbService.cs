using MongoDB.Driver;
using bidendist.API.Models;

namespace bidendist.API.Services
{
    public class MongoDbService
    {
        private readonly IMongoDatabase _database;

        public MongoDbService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("MongoDBSettings:ConnectionString"));
            _database = client.GetDatabase(config.GetValue<string>("MongoDBSettings:DatabaseName"));
        }

        public IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public IMongoCollection<Doctor> Doctors => _database.GetCollection<Doctor>("Doctors");
        public IMongoCollection<Appointment> Appointments => _database.GetCollection<Appointment>("Appointments");
    }
}
