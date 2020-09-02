using System;
using System.ComponentModel.DataAnnotations;

namespace Emveep.TalentHunter.API.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            CreatedBy = "Zaky";
            CreatedTime = DateTime.Now;    
        }

        [Key]
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedTime { get; set; }
    }
}