using Emveep.TalentHunter.API.Models.auth;
using Microsoft.EntityFrameworkCore;

namespace Emveep.TalentHunter.API.Data
{
    public class TalentHunterContext : DbContext
    {
        public TalentHunterContext(DbContextOptions<TalentHunterContext> opt) : base(opt)
        {
            
        }

        public DbSet<TalentHunters> TalentHunters { get; set; }
    }
}