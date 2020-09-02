using System.Collections.Generic;
using Emveep.TalentHunter.API.Models.auth;

namespace Emveep.TalentHunter.API.Data.Interface
{
    public interface ITalentHunterRepo
    {
        bool SaveChanges();

        IEnumerable<TalentHunters> GetAllProfile();
        TalentHunters GetProfilebyId(TalentHunterRequest request);
        void CreateTalentHunter(TalentHunters th);
        void UpdateTalentHunter(TalentHunters th);
        void DeleteTalentHunter(TalentHunters th);
    }
}