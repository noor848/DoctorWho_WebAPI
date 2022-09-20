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
    public class DoctorssRepository:IDoctor
    {
        public  ApplicationContext _context;
        public DoctorssRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void CreateDoctor(Doctor DoctorTable)
        {
            _context.tblDoctors.Add(DoctorTable);
            _context.SaveChanges();
        }
        public void updateDoctorData(Doctor DoctorTable)
        {
                var Doctor = GetDoctorById(DoctorTable.Id);
                          
                Doctor.DoctorName = DoctorTable.DoctorName;
                Doctor.Id = DoctorTable.Id;
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
        public ICollection<Doctor> GetAllDoctors()
        {
            return _context.tblDoctors.Select(s => s).ToList();   
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.tblDoctors.FirstOrDefault(s => s.Id ==id);
        }

    }
}
