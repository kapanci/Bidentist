using bidendist.API.Models;
using bidendist.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace bidendist.API.Controllers
{
    [ApiController]
    [Route("api/appointments")]  // Buradaki Route doğru olacak şekilde düzenlendi
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _service;

        public AppointmentsController(AppointmentService service)
        {
            _service = service;
        }

        // GET: api/appointments
        [HttpGet]
        public async Task<List<Appointment>> Get() => await _service.GetAsync();

        // GET: api/appointments/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> Get(string id)
        {
            var app = await _service.GetByIdAsync(id);
            if (app is null) return NotFound();
            return app;
        }

        // POST: api/appointments
        [HttpPost]
        public async Task<IActionResult> Post(Appointment appointment)
        {
            await _service.CreateAsync(appointment);
            return CreatedAtAction(nameof(Get), new { id = appointment.Id }, appointment);
        }

        // PUT: api/appointments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Appointment appointment)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing is null) return NotFound();

            appointment.Id = id;
            await _service.UpdateAsync(id, appointment);
            return NoContent();
        }

        // DELETE: api/appointments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing is null) return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
