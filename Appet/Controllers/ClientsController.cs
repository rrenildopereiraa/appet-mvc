using Appet.Models;
using Appet.Services;
using Microsoft.AspNetCore.Mvc;

namespace Appet.Controllers
{
    public class ClientsController : Controller
    {
        private readonly AppetContext _context;

        public ClientsController(AppetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Clients.OrderByDescending(c => c.Id).ToList();
            return View(clients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ClientDto clientDto)
        {
            if (!ModelState.IsValid) 
            { 
                return View(clientDto);
            }

            // save the new client in the database
            Client client = new Client()
            {
                Name = clientDto.Name,
                Address = clientDto.Address,
                Phone = clientDto.Phone,
            };

            _context.Clients.Add(client);
            _context.SaveChanges();

            return RedirectToAction("Index", "Clients");
        }

        public IActionResult Edit(int id) 
        { 
            var client = _context.Clients.Find(id);

            if (client == null) {
                return RedirectToAction("Index", "Clients");
            }

            // create clientDto from client
            var clientDto = new ClientDto()
            {
                Name= client.Name,
                Address = client.Address,
                Phone = client.Phone,
            };

            ViewData["ClientId"] = client.Id;

            return View(clientDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, ClientDto clientDto)
        {
            var client = _context.Clients.Find(id);

            if (client == null) {
                return RedirectToAction("Index", "Clients");
            }

            if (!ModelState.IsValid)
            {
                ViewData["ClientId"] = client.Id;
                return View(clientDto);
            }

            // update the client in the database
            client.Name = clientDto.Name;
            client.Address = clientDto.Address;
            client.Phone = clientDto.Phone;

            _context.SaveChanges();
            return RedirectToAction("Index", "CLients");
        }

        public IActionResult Delete(int id)
        {
            var vet = _context.Clients.Find(id);

            if (vet == null)
            {
                return RedirectToAction("Index", "Clients");
            }

            _context.Clients.Remove(vet);
            _context.SaveChanges(true);

            return RedirectToAction("Index", "Clients");
        }
    }
}
