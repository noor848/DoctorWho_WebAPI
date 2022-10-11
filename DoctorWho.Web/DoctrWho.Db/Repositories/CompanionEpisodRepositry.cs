using DoctorWho.Db.Interface;
using DoctrWho.Db.Interface;
using EFCore;
using EfDoctorWho;
using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> InsertCompanionEpisodData(int CompanionId, int EpisodId)
        {
           await _context.AddRangeAsync(
                new CompanionEpisod
                {
                    CompanionId = CompanionId,
                    EpisodId = EpisodId
                }
                );
            return await Save();
        }


        public async Task<bool> DeleteCompanionEpisodData(int CompanionId, int EpisodId)
        {
             _context.Remove(
                new CompanionEpisod
            {
                CompanionId = CompanionId,
                EpisodId = EpisodId
            });
            return await Save();
        }


        public async Task<bool> UpdateCompanionEpisodData(int CompanionId, int EpisodId)
        {

            var CompanionEpisods = await GetCompanionEpisod(CompanionId,EpisodId);

            CompanionEpisods.EpisodId = EpisodId;
            CompanionEpisods.CompanionId = CompanionId;

            return await Save();
        }

        public async Task<CompanionEpisod> GetCompanionEpisod(int CompanionId, int EpisodId)
        {
            return await _context.CompanionEpisods.SingleOrDefaultAsync 
                (b => b.EpisodId == EpisodId && b.CompanionId == CompanionId);
        }


        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
