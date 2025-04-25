using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace bidendist.API.Models
{
    public class Appointment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }

        public string? Reason { get; set; }


    }
}
