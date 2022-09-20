using DoctorWho.Db.Interface;
using EFCore;


namespace DoctorWho.Db.Repositories
{
    public class EnemytblEpisodRepositry : IEnemyToEpisode
    {
        private readonly ApplicationContext _context;
        public EnemytblEpisodRepositry(ApplicationContext context)
        {
            _context = context;
        }
        public  bool InsertEnemyEpisodData(int EnemyId,int EpisodId)
        {
            _context.AddRange(
                new EnemyEpisod{
                    
                        TblEnemyId = EnemyId,
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
