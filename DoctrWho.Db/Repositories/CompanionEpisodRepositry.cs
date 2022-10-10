using DoctorWho.Db.Interface;
using DoctrWho.Db.Interface;
using EFCore;
using EfDoctorWho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class CompanionEpisodRepositry : ICompanionToEpisodeRepository
    {
        private readonly DoctorWhoContext _context;
        public CompanionEpisodRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
        public bool InsertCompanionEpisodData(int CompanionId, int EpisodId)
        {
            _context.AddRange(
                new CompanionEpisod
                {
                    CompanionId = CompanionId,
                    EpisodId = EpisodId
                }
                );
            return Save();
        }


        public bool DeleteCompanionEpisodData(int CompanionId, int EpisodId)
        {
            _context.Remove(
                new CompanionEpisod
            {
                CompanionId = CompanionId,
                EpisodId = EpisodId
            });
            return Save();
        }


        public bool UpdateCompanionEpisodData(int CompanionId, int EpisodId)
        {

            var CompanionEpisods = GetCompanionEpisod(CompanionId,EpisodId);

            CompanionEpisods.EpisodId = EpisodId;
            CompanionEpisods.CompanionId = CompanionId;

            return Save();
        }

        public CompanionEpisod GetCompanionEpisod(int CompanionId, int EpisodId)
        {
            return _context.CompanionEpisods.SingleOrDefault
                (b => b.EpisodId == EpisodId && b.CompanionId == CompanionId);
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
