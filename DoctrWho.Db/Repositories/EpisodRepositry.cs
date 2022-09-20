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
        private readonly ApplicationContext _context;
        public EpisodRepositry(ApplicationContext context)
        {
            _context = context;
        }
        public bool CreateEpisodes(Episod episod,int AuthorId, int DoctorId)
        {
            var Author = _context.tblAuthors.FirstOrDefault(s => s.Id == AuthorId);
            var Doctor = _context.tblDoctors.FirstOrDefault(s => s.Id == DoctorId);


            _context.tblEpisods.Add(
                new EfDoctorWho.Episod
            {
               Id=episod.Id,
               EpisodNumber = episod.EpisodNumber,  
               EpisodDate = episod.EpisodDate,  
               EpisodType = episod.EpisodType,  
               Notes = episod.Notes,
               SeriesNumber = episod.SeriesNumber,
               Title = episod.Title,
               tblAuthor=Author,
               tblDoctor= Doctor

                });
            return Save();
        }

        public Doctor GetDoctor(int DoctorId)
        {
            return _context.tblDoctors.Where(o => o.Id== DoctorId).FirstOrDefault();
        }
        public Author GetAuthor(int AuthorId)
        {
            return _context.tblAuthors.Where(o => o.Id == AuthorId).FirstOrDefault();
        }

        public Episod GetEpisodById(int id)
        {
            return _context.tblEpisods.FirstOrDefault(s => s.Id == id);
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
            return _context.tblEpisods.Select(s => s).ToList();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public int GetLastIdEpisod()
        {
            return _context.tblEpisods.Find(_context.tblEpisods.Max(s=>s.Id)).Id;
        }

    }
}
