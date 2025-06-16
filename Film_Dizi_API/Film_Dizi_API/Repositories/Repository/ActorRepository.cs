using Film_Dizi_API.Data;
using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.Models;
using Film_Dizi_API.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;

namespace Film_Dizi_API.Repositories.Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly ApplicationDbContext _context;
        public ActorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ActorExists(int id)
        {
            return await _context.Actors.AnyAsync(a => a.Id == id);
        }

        public async Task<Actor> CreateActorAysnc(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<Actor?> DeleteActorAsync(int id)
        {
            var actorModel = await _context.Actors.FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (actorModel is null)
            {
                return null;
            }

            _context.Actors.Remove(actorModel);
            await _context.SaveChangesAsync();

            return actorModel;
        }

        public async Task<Actor?> GetActorByIdAsync(int id)
        {
            return await _context.Actors.Include(c => c.Comments).FirstOrDefaultAsync(i => i.Id.Equals(id));
        }

        public async Task<List<Actor>> GetAllActorsAsync()
        {
            return await _context.Actors.Include(c => c.Comments).ToListAsync();
        }

        public async Task<Actor> UpdateActorAysnc(int id, UpdateActorDto actorDto)
        {
            var existingActor = await _context.Actors.FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (existingActor is null)
            {
                return null;
            }

            existingActor.Name = actorDto.Name;
            existingActor.BirthDate = actorDto.BirthDate;
            existingActor.Biography = actorDto.Biography;

            await _context.SaveChangesAsync();

            return existingActor;

        }
    }
}
