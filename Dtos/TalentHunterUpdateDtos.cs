using System;
using System.ComponentModel.DataAnnotations;

namespace Emveep.TalentHunter.API.Dtos
{
    public class TalentHunterUpdateDtos
    {
        public TalentHunterUpdateDtos()
        {
            ModifiedBy = "Zaky";
            ModifiedTime = DateTime.Now;
        }
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
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}