using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctrWho.Db.Interface
{
    public interface ICompanionToEpisode
    {
        bool InsertCompanionEpisodData(int EnemyId, int EpisodId);
    }
}
