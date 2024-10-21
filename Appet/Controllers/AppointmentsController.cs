using Appet.Models;
using Appet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appet.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly AppetContext _context;

        public AppointmentsController(AppetContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var appointment = _context.Appointments.OrderByDescending(c => c.Id).ToList();
            return View(appointment);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(AppointmentDto appointmentDto)
        {
            if (!ModelState.IsValid)
            {
                return View(appointmentDto);
            }

            // save the new appointment in the database
            Appointment appointment = new Appointment()
            {
                ClientName = appointmentDto.ClientName,
                VetName = appointmentDto.VetName,
                AppointmentDateTime = appointmentDto.AppointmentDateTime,
                Notes = appointmentDto.Notes
            };

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return RedirectToAction("Index", "Appointments");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return RedirectToAction("Index", "Appointments");
            }

            // create appointmentDto from appointment
            var appointmentDto = new AppointmentDto()
            {
                ClientName = appointment.ClientName,
                VetName = appointment.VetName,
                AppointmentDateTime = appointment.AppointmentDateTime,
                Notes = appointment.Notes
            };

            ViewData["AppointmentId"] = appointment.Id;

            return View(appointmentDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(int id, AppointmentDto appointmentDto)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return RedirectToAction("Index", "Appointments");
            }

            if (!ModelState.IsValid)
            {
                ViewData["AppointmentId"] = appointment.Id;
                return View(appointmentDto);
            }

            // update the appointment in the database
            appointment.ClientName = appointmentDto.ClientName;
            appointment.VetName = appointmentDto.VetName;
            appointment.AppointmentDateTime = appointmentDto.AppointmentDateTime;
            appointment.Notes = appointmentDto.Notes;

            _context.SaveChanges();
            return RedirectToAction("Index", "Appointments");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var vet = _context.Appointments.Find(id);

            if (vet == null)
            {
                return RedirectToAction("Index", "Appointments");
            }

            _context.Appointments.Remove(vet);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Appointments");
        }
    }
}
