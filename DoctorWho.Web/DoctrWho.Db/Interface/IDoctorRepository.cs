﻿using DoctorWho.Db.Repositories;
using EfDoctorWho;
using System.ComponentModel.DataAnnotations;

namespace DoctorWho.Db.Interface
{
    public interface IDoctorRepository
    {
        public void CreateDoctor(Doctor DoctorTable);
        public Task updateDoctorData(Doctor DoctorTable);
        public Task<bool> DeleteDoctor(int id);
        public Task<IEnumerable<Doctor>> GetAllDoctors();
        public Task<Doctor> GetDoctorById(int id);
        public void GetDoctorNameFunction(int id);
        public void PrintDoctorsNamesView();
        public Task<Doctor> GetDoctorByNumber(int DoctorNum);


    }
}
