using DoctorWho.Db.Interface;
using EFCore;


namespace DoctorWho.Db.Repositories
{
    public class EnemytblEpisodRepositry : IEnemyToEpisode
    {
        private readonly DoctorWhoContext _context;
        public EnemytblEpisodRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
        public  bool InsertEnemyEpisodData(int EnemyId,int EpisodId)
        {
            _context.AddRange(
                new EnemyEpisod{
                    
                        EnemyId = EnemyId,
                        EpisodId = EpisodId
                }
                );
            return Save();
        }

        public bool DeleteEnemyEpisodData(int EnemyId, int EpisodId)
        {
            _context.Remove(
                new EnemyEpisod
                {
                    EnemyId = EnemyId,
                    EpisodId = EpisodId
                });
            return Save();
        }


        public bool UpdateEnemyEpisodData(int EnemyId, int EpisodId)
        {

            var EnemyEpisods = GetEnemyEpisod(EnemyId, EpisodId);

            EnemyEpisods.EpisodId = EpisodId;
            EnemyEpisods.EnemyId = EnemyId;

            return Save();
        }

        public EnemyEpisod GetEnemyEpisod(int EnemyId, int EpisodId)
        {
            return _context.EnemyEpisods.SingleOrDefault
                (b => b.EpisodId == EpisodId && b.EnemyId == EnemyId);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
