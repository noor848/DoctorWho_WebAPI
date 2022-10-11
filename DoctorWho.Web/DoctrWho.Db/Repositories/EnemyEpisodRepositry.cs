using DoctorWho.Db.Interface;
using EFCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories
{
    public class EnemytblEpisodRepositry : IEnemyToEpisodeRepository
    {
        private readonly DoctorWhoContext _context;
        public EnemytblEpisodRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
        public  async Task<bool> InsertEnemyEpisodData(int EnemyId,int EpisodId)
        {
           await  _context.AddRangeAsync(
                new EnemyEpisod{
                    
                        EnemyId = EnemyId,
                        EpisodId = EpisodId
                }
                );
            return await Save();
        }

        public async Task<bool> DeleteEnemyEpisodData(int EnemyId, int EpisodId)
        {
            _context.Remove(
                new EnemyEpisod
                {
                    EnemyId = EnemyId,
                    EpisodId = EpisodId
                });
            return await Save();
        }


        public  async Task<bool> UpdateEnemyEpisodData(int EnemyId, int EpisodId)
        {
            var EnemyEpisods =  await GetEnemyEpisod(EnemyId, EpisodId);
            EnemyEpisods.EpisodId = EpisodId;
            EnemyEpisods.EnemyId = EnemyId;

            return await Save();
        }

        public async Task<EnemyEpisod> GetEnemyEpisod(int EnemyId, int EpisodId)
        {
            return await _context.EnemyEpisods.
                Where(b => b.EpisodId == EpisodId && b.EnemyId == EnemyId).
                SingleOrDefaultAsync();
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
