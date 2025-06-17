using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.Helpers;
using Film_Dizi_API.Models;

namespace Film_Dizi_API.Repositories.Contracts
{
    public interface IActorRepository
    {
        Task<bool> ActorExists(int id);

        Task<List<Actor>> GetAllActorsAsync(QueryObject query);
        Task<Actor?> GetActorByIdAsync(int id);
        Task<Actor> UpdateActorAsync(int id, UpdateActorDto actor);

        Task<Actor?> DeleteActorAsync(int id);
        Task<Actor> CreateActorAysnc(Actor actor);
    }
}
