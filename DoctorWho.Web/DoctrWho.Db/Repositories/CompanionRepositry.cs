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
    public class CompanionRepositry: ICompanionRepository
    {
        private readonly  DoctorWhoContext _context;
        public CompanionRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
     
        public  void CreateCompanion(string ComapnionName, string WhoPlayed)
        {
            _context.Companions.Add(new Companion
            {
                ComapnionName = ComapnionName,
                WhoPlayed = WhoPlayed
            });
            _context.SaveChanges();
        }

        public void UpdateCompanion(int CompanionId , string CompanionName)
        {

            var Companion = GetCompanion(CompanionId);

            Companion.ComapnionName= CompanionName;
    
            _context.SaveChanges();
        }

        public Companion GetCompanion(int CompanionId)
        {
            return _context.Companions.SingleOrDefault(b=>b.Id==CompanionId);
        }

        public void DeleteComapnion(int CompanionId)
        {
            var Companon = GetCompanion(CompanionId);
            if (Companon != null)
            {
                _context.Remove(Companon);
                _context.SaveChanges();
            }
        }

    }
}
