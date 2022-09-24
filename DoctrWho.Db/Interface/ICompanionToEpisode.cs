using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctrWho.Db.Interface
{
    public interface ICompanionToEpisode
    {
       public bool InsertCompanionEpisodData(int EnemyId, int EpisodId);
        public CompanionEpisod GetCompanionEpisod(int CompanionId, int EpisodId);
        public bool DeleteCompanionEpisodData(int CompanionId, int EpisodId);
        bool UpdateCompanionEpisodData(int CompanionId, int EpisodId);
    }
}
