using bidendist.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace bidendist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Geçici veri listesi (veritabanı yok)
        private static List<User> users = new List<User>
        {
            new User { Id = "1", FirstName = "Ali", LastName = "Yılmaz", Email = "ali@example.com", PhoneNumber = "5551234567", Address = "Ankara" },
            new User { Id = "2", FirstName = "Zeynep", LastName = "Kara", Email = "zeynep@example.com", PhoneNumber = "5329876543", Address = "İstanbul" }
        };

        // GET: api/user
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(users);
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public ActionResult<User> CreateUser(User user)
        {
            user.Id = (users.Count + 1).ToString(); // Basit ID ataması
            users.Add(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, User updatedUser)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.Address = updatedUser.Address;

            return NoContent();
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            users.Remove(user);
            return NoContent();
        }
    }
}
