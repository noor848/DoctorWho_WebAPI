using DoctorWho.Db.Interface;
using EFCore;
using EfDoctorWho;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
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
        public async Task updateDoctorData(Doctor DoctorTable)
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
            return await Save();
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors.Select(s => s).ToListAsync();   
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public  async Task<Doctor> GetDoctorByNumber(int DoctorNum)
        {
            return await _context.Doctors.Where(s => s.DoctorNumber == DoctorNum).SingleOrDefaultAsync();
        }
        public async  Task<Doctor> GetDoctorById(int id)
        {
            return await _context.Doctors.Where(s => s.DoctorNumber == id).SingleOrDefaultAsync();
        }

        public async void GetDoctorNameFunction(int DoctorId)
        {
            var response = await _context.DoctorViews.FromSqlRaw($"select * from  GetDoctor({DoctorId})").SingleOrDefaultAsync();
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
