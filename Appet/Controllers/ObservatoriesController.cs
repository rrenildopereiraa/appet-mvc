using Appet.Models;
using Appet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appet.Controllers
{
    public class ObservatoriesController : Controller
    {
        private readonly AppetContext _context;

        public ObservatoriesController(AppetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var observatories = _context.Observatories.OrderByDescending(c => c.Id).ToList();
            return View(observatories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ObservatoryDto observatoryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(observatoryDto);
            }

            // save the new observatory in the database
            Observatory observatory = new Observatory()
            {
                Name = observatoryDto.Name,
                Location = observatoryDto.Location,
                TelescopesCount = observatoryDto.TelescopesCount
            };

            _context.Observatories.Add(observatory);
            _context.SaveChanges();

            return RedirectToAction("Index", "Observatories");
        }

        public IActionResult Edit(int id)
        {
            var observatory = _context.Observatories.Find(id);

            if (observatory == null)
            {
                return RedirectToAction("Index", "Observatories");
            }

            // create observatoryDto from observatory
            var observatoryDto = new ObservatoryDto()
            {
                Name = observatory.Name,
                Location = observatory.Location,
                TelescopesCount = observatory.TelescopesCount
            };

            ViewData["ObservatoryId"] = observatory.Id;

            return View(observatoryDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ObservatoryDto observatoryDto)
        {
            var observatory = _context.Observatories.Find(id);

            if (observatory == null)
            {
                return RedirectToAction("Index", "Observatories");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ObservatoryId"] = observatory.Id;
                return View(observatoryDto);
            }

            // update the observatory in the database
            observatory.Name = observatoryDto.Name;
            observatory.Location = observatoryDto.Location;
            observatory.TelescopesCount = observatoryDto.TelescopesCount;

            _context.SaveChanges();
            return RedirectToAction("Index", "Observatories");
        }

        public IActionResult Delete(int id)
        {
            var vet = _context.Observatories.Find(id);

            if (vet == null)
            {
                return RedirectToAction("Index", "Observatories");
            }

            _context.Observatories.Remove(vet);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Observatories");
        }
    }
}
