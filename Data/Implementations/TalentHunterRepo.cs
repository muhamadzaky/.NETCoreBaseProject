using System;
using System.Collections.Generic;
using System.Linq;
using Emveep.TalentHunter.API.Data.Interface;
using Emveep.TalentHunter.API.Models.auth;

namespace Emveep.TalentHunter.API.Data.Implementations
{
    public class TalentHunterRepo : ITalentHunterRepo
    {
        private readonly TalentHunterContext _context;

        public TalentHunterRepo(TalentHunterContext context)
        {
            _context = context;
        }

        public void CreateTalentHunter(TalentHunters th)
        {
            if (th == null)
            {
                throw new ArgumentNullException(nameof(th));
            }

            _context.TalentHunters.Add(th);
        }

        public void DeleteTalentHunter(TalentHunters th)
        {
            if (th == null)
            {
                throw new ArgumentNullException(nameof(th));
            }
            _context.TalentHunters.Remove(th);
        }

        public IEnumerable<TalentHunters> GetAllProfile()
        {
            return _context.TalentHunters.ToList().Where(x => x.isDeleted == false);
        }

        public TalentHunters GetProfilebyId(TalentHunterRequest request)
        {
            return _context.TalentHunters.FirstOrDefault(x => x.Id == request.id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateTalentHunter(TalentHunters th)
        {
            // Do Nothing
        }
    }
}