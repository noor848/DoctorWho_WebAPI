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
    public class DoctorssRepository: IDoctorRepository
    {
        public  DoctorWhoContext _context;
        public DoctorssRepository(DoctorWhoContext context)
        {
            _context = context;
        }
        public  async void CreateDoctor(Doctor DoctorTable)
        {
             await _context.Doctors.AddAsync(DoctorTable);
            _context.SaveChanges();
        }
        public async void updateDoctorData(Doctor DoctorTable)
        {
                var Doctor = await  GetDoctorByNumber(DoctorTable.DoctorNumber);
                          
                Doctor.DoctorName = DoctorTable.DoctorName;
               // Doctor.Id = DoctorTable.Id;
                Doctor.DoctorNumber = DoctorTable.DoctorNumber;
                Doctor.BirthDate = DoctorTable.BirthDate;
                Doctor.FirstEpisodDate = DoctorTable.FirstEpisodDate;
                Doctor.LastEpisodDate = DoctorTable.LastEpisodDate;

                _context.SaveChanges();
        }
        public async Task<bool> DeleteDoctor(int id)
        {
            var Doctor = await GetDoctorById(id);

            if (Doctor != null)
            {
                _context.Remove(Doctor);
               
            }
            return Save();
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors.Select(s => s).ToListAsync();   
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public  async Task<Doctor> GetDoctorByNumber(int DoctorNum)
        {
            return await _context.Doctors.FirstAsync(s => s.DoctorNumber == DoctorNum);
        }
        public async  Task<Doctor> GetDoctorById(int id)
        {
            return await _context.Doctors.FirstAsync(s => s.DoctorNumber == id);
        }

        public async void GetDoctorNameFunction(int DoctorId)
        {
            var response = await _context.DoctorViews.FromSqlRaw($"select * from  GetDoctor({DoctorId})").FirstAsync();
            Console.WriteLine($"Doctor Name has Id ={DoctorId} is {response.DoctorName}");
        }

        public async void PrintDoctorsNamesView()
        {
            var NameList = await _context.DoctorViews.ToListAsync();

            foreach (var name in NameList)
            {
                Console.Write($"Doctor's Name {name.Id}: {name.DoctorName}, ");
            }
      

        }

               

    }
}
