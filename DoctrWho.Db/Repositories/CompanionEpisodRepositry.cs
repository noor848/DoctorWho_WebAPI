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
    public class CompanionEpisodRepositry : ICompanionToEpisode
    {
        private readonly ApplicationContext _context;
        public CompanionEpisodRepositry(ApplicationContext context)
        {
            _context = context;
        }
        public bool InsertCompanionEpisodData(int CompanionId, int EpisodId)
        {
            _context.AddRange(
                new CompanionEpisod
                {
                    TblCompanionId = CompanionId,
                    TblEpisodId = EpisodId
                }
                );
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
