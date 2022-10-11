using DoctorWho.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctrWho.Db.Interface
{
    public interface ICompanionToEpisodeRepository
    {
       public Task<bool> InsertCompanionEpisodData(int EnemyId, int EpisodId);
        public Task<CompanionEpisod> GetCompanionEpisod(int CompanionId, int EpisodId);
        public Task<bool> DeleteCompanionEpisodData(int CompanionId, int EpisodId);
        Task<bool> UpdateCompanionEpisodData(int CompanionId, int EpisodId);
    }
}
