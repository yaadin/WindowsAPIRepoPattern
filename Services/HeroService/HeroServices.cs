using HeroesAPI.Data;
using HeroesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;

namespace HeroesAPI.Services.HeroService
{
    public class HeroServices : IHeroInterface
    {
        private readonly ApplicationDbContext _db;
        public HeroServices(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<HeroModel>> Getall()
        {
            var hher = await _db.heroes.ToListAsync();
            if (hher == null)
            {
                return null;
            }
            return hher;
        }
        public async Task<HeroModel> PostHero(HeroModel model)
        {
            await _db.heroes.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }
        public async Task<HeroModel> GetByiD(int id)
        {
            var hher = await _db.heroes.FirstOrDefaultAsync(u=> u.id == id);
            if (hher == null)
            {
                return null;
            }
            return hher;
        }
        public async Task<bool> Delete(int id)
        {
            var hher = await _db.heroes.FirstOrDefaultAsync(u => u.id == id);
            if (hher == null)
            {
                return false;
            }
            _db.heroes.Remove(hher);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
