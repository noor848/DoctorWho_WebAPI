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
    public class DoctorWhoContext : DbContext
    {
        public DoctorWhoContext(DbContextOptions<DoctorWhoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EnemyEpisod>().HasKey(s => new { s.EpisodId,s.EnemyId });
            modelBuilder.Entity<CompanionEpisod>().HasKey(s => new { s.EpisodId,s.CompanionId });

        }

        public DbSet<Enemy> Enemys { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Companion> Companions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Episod> Episods { get; set; }
        public DbSet<EnemyEpisod> EnemyEpisods { get; set; }
        public DbSet<CompanionEpisod> CompanionEpisods { get; set; }
        public DbSet<DoctorView> DoctorViews { get; set; }
    }
}
