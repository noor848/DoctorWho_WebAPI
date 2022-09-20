using DoctorWho.Db;
using EfDoctorWho;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnemyEpisod>().HasKey(s => new { s.TblEpisodId,s.TblEnemyId });
            modelBuilder.Entity<CompanionEpisod>().HasKey(s => new { s.TblEpisodId,s.TblCompanionId });
        }

        public DbSet<Enemy> tblEnemys { get; set; }
        public DbSet<Author> tblAuthors { get; set; }
        public DbSet<Companion> tblCompanions { get; set; }
        public DbSet<Doctor> tblDoctors { get; set; }
        public DbSet<Episod> tblEpisods { get; set; }
        public DbSet<EnemyEpisod> tblEnemytblEpisods { get; set; }
        public DbSet<CompanionEpisod> tblCompaniontblEpisods { get; set; }

    }
}
