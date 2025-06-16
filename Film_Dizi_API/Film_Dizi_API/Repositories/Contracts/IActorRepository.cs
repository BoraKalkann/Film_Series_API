using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.Models;

namespace Film_Dizi_API.Repositories.Contracts
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllActorsAsync();
        Task<Actor?> GetActorByIdAsync(int id);
        Task<Actor> CreateActorAysnc(Actor actor);
        Task<Actor> UpdateActorAysnc(int id, UpdateActorDto actorDto);
        Task<Actor?> DeleteActorAsync(int id);
        Task<bool> ActorExists(int id);
    }
}
