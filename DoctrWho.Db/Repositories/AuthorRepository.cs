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
    public class AuthorRepository : lAuthorRepository
    {
        private readonly  DoctorWhoContext _context;
        public AuthorRepository(DoctorWhoContext context)
        {
            _context = context;
        }

        public  void CreateAuthor(string AuthorName)
        {
            if (!string.IsNullOrEmpty(AuthorName))
            {
                _context.Authors.Add(new EfDoctorWho.Author
                {
                    AuthorName = AuthorName
                });
                _context.SaveChanges();
            }

        }

        public  bool updateAuthorName(int id, string AuthorName)
        {
            var Author = GetAuthorById(id);
            Author.AuthorName = AuthorName;
            return Save();
        }

        public  void DeleteAuthor(int id)
        {
            var Author = GetAuthorById(id);
            if (Author != null)
            {
                _context.Remove(Author);
                _context.SaveChanges();
            }
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Find(id);
        }

    }
}
