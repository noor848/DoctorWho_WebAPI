using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDoctorWho
{
    public class Doctor
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodDate { get; set; }
        public DateTime LastEpisodDate { get; set; }
        public ICollection<Episod> Episod { get; set; }
    }
}

