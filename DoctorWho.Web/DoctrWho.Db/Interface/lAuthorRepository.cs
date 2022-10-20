using EfDoctorWho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Interface
{
    public interface lAuthorRepository
    {
        public void CreateAuthor(string AuthorName);
        public Task<bool> updateAuthorName(int id,string AuthorName);
        public  void DeleteAuthor(int id);
        public Task<Author> GetAuthorById(int id);

    }
}
