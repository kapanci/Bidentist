namespace bidendist.API.Models
{
    public class Doctor
    {
        public string Id { get; set; } // Doktora ait benzersiz kimlik
        public string FirstName { get; set; } // Doktorun adı
        public string LastName { get; set; } // Doktorun soyadı
        public string Specialization { get; set; } // Doktorun uzmanlık alanı (örneğin: Diş Hekimi)
        public string Email { get; set; } // Doktorun e-posta adresi
        public string PhoneNumber { get; set; } // Doktorun telefon numarası
    }
}
