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
    public class EnemyRepositry: IEnemyRepository
    {
        private readonly DoctorWhoContext _context;
        public EnemyRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
        public async void CreateEnemy(string description, string EnemyName)
        {
            await _context.Enemys.AddAsync(new Enemy
            {
                Description = description,
                EnemyName = EnemyName,
            });
            _context.SaveChanges();
        }
 
        public async void DeleteEnemy(int id)
        {
            var Enemy = await GetEnemyById(id);
            if (Enemy != null)
            {
                _context.Remove(Enemy);
                _context.SaveChanges();
            }
        }

        public async void updateEnemyData(Enemy enemy)
        {
            var Enemy = await GetEnemyById(enemy.Id);

            Enemy.Description = enemy.Description;
            Enemy.EnemyName=enemy.EnemyName;

            _context.SaveChanges();
        }

        public async Task<Enemy> GetEnemyById(int id)
        {
            return await _context.Enemys.FindAsync(id);
        }
        public async void GetEnemyProcedure()
        {
            var EnemyNameList = await _context.Enemys.FromSqlRaw("EXECUTE GetEnemiesName").ToListAsync();
            foreach (var enemy in EnemyNameList)
            {
                Console.Write($"Enemy's Name {enemy.Id}: {enemy.EnemyName}, ");
            }
            Console.WriteLine("");
        }
    }
}
