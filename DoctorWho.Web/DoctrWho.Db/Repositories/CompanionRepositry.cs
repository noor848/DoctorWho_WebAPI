using DoctorWho.Db.Interface;
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
    public class CompanionRepositry: ICompanionRepository
    {
        private readonly  DoctorWhoContext _context;
        public CompanionRepositry(DoctorWhoContext context)
        {
            _context = context;
        }
     
        public async  void CreateCompanion(string ComapnionName, string WhoPlayed)
        {
            await _context.Companions.AddAsync(new Companion
            {
                ComapnionName = ComapnionName,
                WhoPlayed = WhoPlayed
            });
            _context.SaveChanges();
        }

        public async void UpdateCompanion(int CompanionId , string CompanionName)
        {

            var Companion = await GetCompanion(CompanionId);

            Companion.ComapnionName= CompanionName;
    
            _context.SaveChanges();
        }

        public async Task<Companion> GetCompanion(int CompanionId)
        {
            return await _context.Companions.FirstAsync(b => b.Id == CompanionId);
        }

        public async void DeleteComapnion(int CompanionId)
        {
            var Companon = await GetCompanion(CompanionId);
            if (Companon != null)
            {
                _context.Remove(Companon);
                _context.SaveChanges();
            }
        }

    }
}
