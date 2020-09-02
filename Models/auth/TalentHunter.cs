using System.ComponentModel.DataAnnotations;

namespace Emveep.TalentHunter.API.Models.auth
{
    public class TalentHunters : BaseModel
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
        [MaxLength(250)]
        public string address { get; set; }
        [Required]
        public string logo { get; set; }
        [Required]
        public bool isDeleted { get; set; }
    }
}