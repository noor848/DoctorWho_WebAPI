using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDoctorWho
{
    public class Episod
    {
        public int Id { get; set; }
        public string SeriesNumber { get; set; }
        public int EpisodNumber { get; set; }
        public string EpisodType { get; set; }
        public string Title { get; set; }
        public DateTime EpisodDate { get; set; }
        public string Notes { get; set; }
        public ICollection<Companion> Companion { get; set; }
        public ICollection<Enemy> Enemy { get; set; }
        public Doctor Doctor { get; set;  }
        public Author Author { get; set; }

    }
}
