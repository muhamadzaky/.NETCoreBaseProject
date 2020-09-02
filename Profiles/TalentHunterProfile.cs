using AutoMapper;
using Emveep.TalentHunter.API.Dtos;
using Emveep.TalentHunter.API.Models.auth;

namespace Emveep.TalentHunter.API.Profiles
{
    public class TalentHunterProfile : Profile
    {
        public TalentHunterProfile()
        {
            // Source -> Target
            CreateMap<TalentHunters, TalentHunterDtos>();
            CreateMap<TalentHunterCreateDtos, TalentHunters>();
            CreateMap<TalentHunterUpdateDtos, TalentHunters>();
            CreateMap<TalentHunters, TalentHunterUpdateDtos>();
        }
    }
}