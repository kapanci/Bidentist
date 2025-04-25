namespace bidendist.API.Models
{
    public class User
    {
        public string Id { get; set; } // Kullanıcıya ait benzersiz kimlik
        public string FirstName { get; set; } // Kullanıcının adı
        public string LastName { get; set; } // Kullanıcının soyadı
        public string Email { get; set; } // Kullanıcının e-posta adresi
        public string PhoneNumber { get; set; } // Kullanıcının telefon numarası
        public string Address { get; set; } // Kullanıcının adresi
    }
}
