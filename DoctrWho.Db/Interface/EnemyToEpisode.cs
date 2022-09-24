using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Interface
{
    public interface IEnemyToEpisode
    {
        public bool InsertEnemyEpisodData(int EnemyId, int EpisodId);
        bool DeleteEnemyEpisodData(int EnemyId, int EpisodId);
        bool UpdateEnemyEpisodData(int EnemyId, int EpisodId);
        EnemyEpisod GetEnemyEpisod(int EnemyId, int EpisodId);
    }
}
