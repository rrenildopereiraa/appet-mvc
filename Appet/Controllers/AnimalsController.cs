using Appet.Models;
using Appet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appet.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AppetContext _context;

        public AnimalsController(AppetContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var animals = _context.Animals.OrderByDescending(c => c.Id).ToList();
            return View(animals);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(AnimalDto animalDto)
        {
            if (!ModelState.IsValid)
            {
                return View(animalDto);
            }

            // save the new animal in the database
            Animal animal = new Animal()
            {
                Name = animalDto.Name,
                Species = animalDto.Species,
                Owner = animalDto.Owner,
            };

            _context.Animals.Add(animal);
            _context.SaveChanges();

            return RedirectToAction("Index", "Animals");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var animal = _context.Animals.Find(id);

            if (animal == null)
            {
                return RedirectToAction("Index", "Animals");
            }

            // create AnimalDto from animal
            var animalDto = new AnimalDto()
            {
                Name = animal.Name,
                Species = animal.Species,
                Owner = animal.Owner
            };

            ViewData["AnimalId"] = animal.Id;

            return View(animalDto);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(int id, AnimalDto animalDto)
        {
            var animal = _context.Animals.Find(id);

            if (animal == null)
            {
                return RedirectToAction("Index", "Animals");
            }

            if (!ModelState.IsValid)
            {
                ViewData["AnimalId"] = animal.Id;
                return View(animalDto);
            }

            // update the animal in the database
            animal.Name = animalDto.Name;
            animal.Species = animalDto.Species;
            animal.Owner = animalDto.Owner;

            _context.SaveChanges();
            return RedirectToAction("Index", "Animals");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var vet = _context.Animals.Find(id);

            if (vet == null)
            {
                return RedirectToAction("Index", "Animals");
            }

            _context.Animals.Remove(vet);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Animals");
        }
    }
}
