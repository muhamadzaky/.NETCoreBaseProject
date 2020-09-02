using System.ComponentModel.DataAnnotations;
using Emveep.TalentHunter.API.Models;

namespace Emveep.TalentHunter.API.Dtos
{
    public class TalentHunterCreateDtos : BaseModel
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string website { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string logo { get; set; }
    }
}