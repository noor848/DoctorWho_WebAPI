using EfDoctorWho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Interface
{
    public  interface IEnemyRepository
    {
        public void CreateEnemy(string description, string EnemyName);
        public void DeleteEnemy(int id);
        public Enemy GetEnemyById(int id);
        public void updateEnemyData(Enemy enemy);
        public void GetEnemyProcedure();
    }
}
