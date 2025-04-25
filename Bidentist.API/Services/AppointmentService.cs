using bidendist.API.Models;
using bidendist.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace bidendist.API.Services
{
    public class AppointmentService
    {
        private readonly IMongoCollection<Appointment> _appointments;

        public AppointmentService(IOptions<MongoDBSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _appointments = database.GetCollection<Appointment>(mongoSettings.Value.AppointmentCollectionName);
        }

        public async Task<List<Appointment>> GetAsync() =>
            await _appointments.Find(_ => true).ToListAsync();

        public async Task<Appointment> GetByIdAsync(string id) =>
            await _appointments.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Appointment appointment) =>
            await _appointments.InsertOneAsync(appointment);

        public async Task UpdateAsync(string id, Appointment updated) =>
            await _appointments.ReplaceOneAsync(a => a.Id == id, updated);

        public async Task DeleteAsync(string id) =>
            await _appointments.DeleteOneAsync(a => a.Id == id);
    }
}
