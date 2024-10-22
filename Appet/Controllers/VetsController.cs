using Appet.Models;
using Appet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appet.Controllers
{
    public class VetsController : Controller
    {
        private readonly AppetContext _context;

        public VetsController(AppetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vets = _context.Vets.OrderByDescending(c => c.Id).ToList();
            return View(vets);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VetDto vetDto)
        {
            if (!ModelState.IsValid)
            {
                return View(vetDto);
            }

            // save the new vet in the database
            Vet vet = new Vet()
            {
                Name = vetDto.Name,
                Specialization = vetDto.Specialization,
                Phone = vetDto.Phone,
            };

            _context.Vets.Add(vet);
            _context.SaveChanges();

            return RedirectToAction("Index", "Vets");
        }

        public IActionResult Edit(int id)
        {
            var vet = _context.Vets.Find(id);

            if (vet == null)
            {
                return RedirectToAction("Index", "Vets");
            }

            // create vetDto from observatory
            var vetDto = new VetDto()
            {
                Name = vet.Name,
                Specialization = vet.Specialization,
                Phone = vet.Phone,
            };

            ViewData["VetId"] = vet.Id;

            return View(vetDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, VetDto vetDto)
        {
            var vet = _context.Vets.Find(id);

            if (vet == null)
            {
                return RedirectToAction("Index", "Vets");
            }

            if (!ModelState.IsValid)
            {
                ViewData["VetId"] = vet.Id;
                return View(vetDto);
            }

            // update the vet in the database
            vet.Name = vetDto.Name;
            vet.Specialization = vetDto.Specialization;
            vet.Phone = vetDto.Phone;

            _context.SaveChanges();
            return RedirectToAction("Index", "Vets");
        }

        public IActionResult Delete (int id) 
        { 
            var vet = _context.Vets.Find(id);

            if(vet == null)
            {
                return RedirectToAction("Index", "Vets");
            }

            _context.Vets.Remove(vet);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Vets");
        }
    }
}
