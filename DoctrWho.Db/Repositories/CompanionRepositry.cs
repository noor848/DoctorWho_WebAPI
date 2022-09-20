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
    public class CompanionRepositry: ICompanion
    {
        private readonly  ApplicationContext _context;
        public CompanionRepositry(ApplicationContext context)
        {
            _context = context;
        }
     
        public  void CreateCompanion(string ComapnionName, string WhoPlayed)
        {
            _context.tblCompanions.Add(new Companion
            {
                ComapnionName = ComapnionName,
                WhoPlayed = WhoPlayed
            });
            _context.SaveChanges();
        }
       

    }
}
