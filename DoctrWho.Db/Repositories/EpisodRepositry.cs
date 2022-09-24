using DoctorWho.Db.Interface;
using EFCore;
using EfDoctorWho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Repositories
{
    public class EpisodRepositry:IEpisod
    {
        private readonly DoctorWhoContext _context;
        public EpisodRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
        public bool CreateEpisodes(Episod episod,int AuthorId, int DoctorId)
        {
            var Author = GetAuthor(AuthorId);
            var Doctor = GetDoctor(DoctorId);


            _context.Episods.Add(
                new EfDoctorWho.Episod
            {
               Id=episod.Id,
               EpisodNumber = episod.EpisodNumber,  
               EpisodDate = episod.EpisodDate,  
               EpisodType = episod.EpisodType,  
               Notes = episod.Notes,
               SeriesNumber = episod.SeriesNumber,
               Title = episod.Title,
               Author=Author,
               Doctor= Doctor

                });
            return Save();
        }

        public Doctor GetDoctor(int DoctorId)
        {
            return _context.Doctors.Where(o => o.Id== DoctorId).FirstOrDefault();
        }
        public Author GetAuthor(int AuthorId)
        {
            return _context.Authors.Where(o => o.Id == AuthorId).FirstOrDefault();
        }

        public Episod GetEpisodById(int id)
        {
            return _context.Episods.FirstOrDefault(s => s.Id == id);
        }

        public void DeleteEpisod(int id) 
        {
                var Episod = GetEpisodById(id);
                if (Episod != null)
                {
                _context.Remove(Episod);
                _context.SaveChanges();
                }
        }

        public ICollection<Episod> GetAllEpisods()
        {
            return _context.Episods.Select(s => s).ToList();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public int GetLastIdEpisod()
        {
            return _context.Episods.Find(_context.Episods.Max(s=>s.Id)).Id;
        }


    }
}
