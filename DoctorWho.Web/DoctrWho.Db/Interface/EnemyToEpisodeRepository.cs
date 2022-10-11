using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Interface
{
    public interface IEnemyToEpisodeRepository
    {
        public Task<bool> InsertEnemyEpisodData(int EnemyId, int EpisodId);
        Task<bool> DeleteEnemyEpisodData(int EnemyId, int EpisodId);
        Task<bool> UpdateEnemyEpisodData(int EnemyId, int EpisodId);
        Task<EnemyEpisod> GetEnemyEpisod(int EnemyId, int EpisodId);
    }
}
