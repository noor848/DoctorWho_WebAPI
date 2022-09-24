using EfDoctorWho;

namespace DoctorWho.Db.Interface
{
    public interface IDoctor
    {
        public void CreateDoctor(Doctor DoctorTable);
        public void updateDoctorData(Doctor DoctorTable);
        public bool DeleteDoctor(int id);
        public ICollection<Doctor> GetAllDoctors();
        public Doctor GetDoctorById(int id);

    }
}
