namespace bidendist.API.Models
{
    public class Appointments
    {
        public string Id { get; set; }
        public string PatientId { get; set; } // Randevuya katılan hastanın kimliği
        public string DoctorId { get; set; } // Randevuya katılan doktorun kimliği
        public DateTime AppointmentDate { get; set; } // Randevu tarihi
        public string Reason { get; set; } // Randevunun nedeni (örneğin: muayene, kontroller vs.)
        public string Status { get; set; } // Randevu durumu (Bekliyor, Gerçekleşti, İptal Edildi)
    }
}
