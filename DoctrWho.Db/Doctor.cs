using AutoMapper;
using AutoMapper.Configuration.Annotations;
using DoctorWho.Db.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDoctorWho
{
    [AutoMap(typeof(Doctor))]
    public class Doctor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public int DoctorNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime FirstEpisodDate { get; set; }
        public DateTime LastEpisodDate { get; set; }
        public ICollection<Episod> Episod { get; set; }
    }
}

