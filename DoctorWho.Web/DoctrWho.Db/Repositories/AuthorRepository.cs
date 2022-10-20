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

        public async  void CreateAuthor(string AuthorName)
        {
            if (!string.IsNullOrEmpty(AuthorName))
            {
                await _context.Authors.AddAsync (new EfDoctorWho.Author
                {
                    AuthorName = AuthorName
                });
                 _context.SaveChanges();
            }

        }

        public async  Task<bool> updateAuthorName(int id, string AuthorName)
        {
            var Author = await GetAuthorById(id);
            Author.AuthorName = AuthorName;
            return await Save();
        }

        public async  void DeleteAuthor(int id)
        {
            var Author = await GetAuthorById(id);
            if (Author != null)
            {
                 _context.Remove(Author);
                _context.SaveChanges();
            }
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

    }
}
