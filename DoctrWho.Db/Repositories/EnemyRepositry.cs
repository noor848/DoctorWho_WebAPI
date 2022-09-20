using DoctorWho.Db.Interface;
using EFCore;
using EfDoctorWho;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EnemyRepositry: IEnemy
    {
        private readonly ApplicationContext _context;
        public EnemyRepositry(ApplicationContext context)
        {
            _context = context;
        }
        public void CreateEnemy(string description, string EnemyName)
        {
            _context.tblEnemys.Add(new EfDoctorWho.Enemy
            {
                Description = description,
                EnemyName = EnemyName,
            });
            _context.SaveChanges();
        }
 
        public void DeleteEnemy(int id)
        {
            var Enemy = GetEnemyById(id);
            if (Enemy != null)
            {
                _context.Remove(Enemy);
                _context.SaveChanges();
            }
        }

        public Enemy GetEnemyById(int id)
        {
            return _context.tblEnemys.Find(id);
        }

    }
}
