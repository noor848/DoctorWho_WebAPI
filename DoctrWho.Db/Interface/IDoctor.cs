using EfDoctorWho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorWho.Db.Interface
{
    public interface IDoctor
    {
        public void CreateDoctor(Doctor DoctorTable);
        public void updateDoctorData(Doctor DoctorTable);
        public bool DeleteDoctor(int id);
        public ICollection<Doctor> GetAllDoctors();
    }
}
