using DoctorWho.Db.Repositories;
using EfDoctorWho;

namespace DoctorWho.Db.Interface
{
    public interface IDoctorRepository
    {
        public void CreateDoctor(Doctor DoctorTable);
        public void updateDoctorData(Doctor DoctorTable);
        public bool DeleteDoctor(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Doctor GetDoctorById(int id);
        public void GetDoctorNameFunction(int id);
        public void PrintDoctorsNamesView();
        public Doctor GetDoctorByNumber(int DoctorNum);


    }
}
