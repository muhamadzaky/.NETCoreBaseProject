using Emveep.TalentHunter.API.Dtos;

namespace Emveep.TalentHunter.API.Controllers.Model
{
    public class TalentHunterResponse
    {
        public BaseResponse Meta { get; set; }
        public TalentHunterDtos Data { get; set; }
    }
}