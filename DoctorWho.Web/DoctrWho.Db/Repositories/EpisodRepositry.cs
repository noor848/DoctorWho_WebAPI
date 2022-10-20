using DoctorWho.Db.Interface;
using DoctorWho.validation;
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
    public class EpisodRepositry: IEpisodRepository
    {
        private readonly DoctorWhoContext _context;
        public EpisodRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateEpisodes(Episod episod,int AuthorId, int DoctorId)
        {
            var Author = await GetAuthor(AuthorId);
            var Doctor = await  GetDoctor(DoctorId);
            var validator = new EpisodValidator();
            var EpisodData = new Episod
            {
                Id = episod.Id,
                EpisodNumber = episod.EpisodNumber,
                EpisodDate = episod.EpisodDate,
                EpisodType = episod.EpisodType,
                Notes = episod.Notes,
                SeriesNumber = episod.SeriesNumber,
                Title = episod.Title,
                Author = Author,
                Doctor = Doctor

            };
            var result = validator.Validate(EpisodData);

            if (result.IsValid)
            {
                Console.WriteLine("valos");
                await _context.Episods.AddAsync(EpisodData);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<Doctor> GetDoctor(int DoctorId)
        {
            return await _context.Doctors.Where(o => o.Id == DoctorId).FirstAsync();
        }
        public async Task<Author> GetAuthor(int AuthorId)
        {
            return  await _context.Authors.Where(o => o.Id == AuthorId).FirstAsync();
        }

        public async  Task <Episod> GetEpisodById(int id)
        {
            return  await _context.Episods.Where(s => s.Id == id).FirstAsync();
        }

        public async void DeleteEpisod(int id) 
        {
                var Episod = await GetEpisodById(id);
                if (Episod != null)
                {
                _context.Remove(Episod);
                _context.SaveChanges();
                }
        }

        public async Task<ICollection<Episod>> GetAllEpisods()
        {
            return await _context.Episods.Select(s => s).ToListAsync();

        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<int>GetLastIdEpisod()
        {
             var EpisodId = await  _context.Episods.FindAsync(_context.Episods.Max(s => s.Id));
            return EpisodId.Id;
        }


    }
}
