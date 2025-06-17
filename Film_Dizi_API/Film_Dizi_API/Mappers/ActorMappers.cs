using Film_Dizi_API.DTOs.Actor;
using Film_Dizi_API.Models;

namespace Film_Dizi_API.Mappers
{
    public static class ActorMappers
    {
        public static ActorDto ToActorDto(this Actor actorModel)
        {
            return new ActorDto
            {
                Id = actorModel.Id,
                Name = actorModel.Name,
                Biography = actorModel.Biography,
                BirthDate = actorModel.BirthDate,
                Comments = actorModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Actor ToActorCreateFromDto(this CreateActorDto actorDto)
        {
            return new Actor
            {
                Name = actorDto.Name,
                Biography = actorDto.Biography,
                BirthDate = actorDto.BirthDate,

            };
        }
    }
}
