using Emveep.TalentHunter.API.Models;

namespace Emveep.TalentHunter.API.Dtos
{
    public class TalentHunterDtos : BaseModel
    {
        public string email { get; set; }
        public string name { get; set; }
        public string website { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string logo { get; set; }
    }
}