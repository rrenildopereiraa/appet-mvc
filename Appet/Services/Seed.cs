using Microsoft.EntityFrameworkCore;

namespace Appet.Services
{
    public class Seed
    {
        private readonly AppetContext _context;

        public Seed(AppetContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
