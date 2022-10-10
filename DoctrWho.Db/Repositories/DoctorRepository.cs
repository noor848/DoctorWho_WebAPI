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
        public  void CreateDoctor(Doctor DoctorTable)
        {
             _context.Doctors.Add(DoctorTable);
            _context.SaveChanges();
        }
        public void updateDoctorData(Doctor DoctorTable)
        {
                var Doctor =  GetDoctorByNumber(DoctorTable.DoctorNumber);
                          
                Doctor.DoctorName = DoctorTable.DoctorName;
               // Doctor.Id = DoctorTable.Id;
                Doctor.DoctorNumber = DoctorTable.DoctorNumber;
                Doctor.BirthDate = DoctorTable.BirthDate;
                Doctor.FirstEpisodDate = DoctorTable.FirstEpisodDate;
                Doctor.LastEpisodDate = DoctorTable.LastEpisodDate;

                _context.SaveChanges();
        }
        public bool DeleteDoctor(int id)
        {
            var Doctor = GetDoctorById(id);

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

        public Doctor GetDoctorByNumber(int DoctorNum)
        {
            return _context.Doctors.FirstOrDefault(s => s.DoctorNumber == DoctorNum);
        }
        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.FirstOrDefault(s => s.DoctorNumber == id);
        }

        public void GetDoctorNameFunction(int DoctorId)
        {
            var response = _context.DoctorViews.FromSqlRaw($"select * from  GetDoctor({DoctorId})").ToList().FirstOrDefault();
            Console.WriteLine($"Doctor Name has Id ={DoctorId} is {response.DoctorName}");
        }

        public void PrintDoctorsNamesView()
        {
            var NameList = _context.DoctorViews.ToList();

            foreach (var name in NameList)
            {
                Console.Write($"Doctor's Name {name.Id}: {name.DoctorName}, ");
            }
      

        }

               

    }
}
