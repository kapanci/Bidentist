using bidendist.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace bidendist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        // Bu örnekte veritabanı bağlantısı olmadan basit bir listeyi döndürüyoruz
        private static List<Doctor> doctors = new List<Doctor>
        {
            new Doctor { Id = "1", FirstName = "Dr. Ahmet", LastName = "Kara", Specialization = "Diş Hekimi", Email = "ahmetdental@example.com", PhoneNumber = "1112223333" },
            new Doctor { Id = "2", FirstName = "Dr. Ayşe", LastName = "Öztürk", Specialization = "Genel Cerrah", Email = "ayse.surgery@example.com", PhoneNumber = "4445556666" }
        };

        // GET: api/doctor
        [HttpGet]
        public ActionResult<List<Doctor>> GetAllDoctors()
        {
            return Ok(doctors);
        }

        // GET: api/doctor/{id}
        [HttpGet("{id}")]
        public ActionResult<Doctor> GetDoctorById(string id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/doctor
        [HttpPost]
        public ActionResult<Doctor> CreateDoctor(Doctor doctor)
        {
            doctor.Id = (doctors.Count + 1).ToString();  // Basit bir ID ataması
            doctors.Add(doctor);
            return CreatedAtAction(nameof(GetDoctorById), new { id = doctor.Id }, doctor);
        }

        // PUT: api/doctor/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateDoctor(string id, Doctor updatedDoctor)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            doctor.FirstName = updatedDoctor.FirstName;
            doctor.LastName = updatedDoctor.LastName;
            doctor.Specialization = updatedDoctor.Specialization;
            doctor.Email = updatedDoctor.Email;
            doctor.PhoneNumber = updatedDoctor.PhoneNumber;

            return NoContent();  // 204 No Content döndür
        }

        // DELETE: api/doctor/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteDoctor(string id)
        {
            var doctor = doctors.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            doctors.Remove(doctor);
            return NoContent();  // 204 No Content döndür
        }
    }
}
