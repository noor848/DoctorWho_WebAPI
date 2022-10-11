using EfDoctorWho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Interface
{
    public  interface ICompanionRepository
    {
        public void CreateCompanion(string ComapnionName, string WhoPlayed);
        public void UpdateCompanion(int CompanionId, string CompanionName);
        public Task<Companion> GetCompanion(int CompanionId);
        public void DeleteComapnion(int CompanionId);

    }
}
