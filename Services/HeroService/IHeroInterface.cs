using HeroesAPI.Data;
using HeroesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroesAPI.Services.HeroService
{
    public interface IHeroInterface
    {
        Task<IEnumerable<HeroModel>> Getall();
        Task<HeroModel> PostHero(HeroModel model);
        Task<HeroModel> GetByiD(int id);

    }
}
