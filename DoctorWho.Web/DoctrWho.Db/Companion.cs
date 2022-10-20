using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDoctorWho
{
    public class Companion
    {
        public int Id { get; set; }
        public string ComapnionName { get; set; }
        public string WhoPlayed { get; set; }
        public ICollection<Episod> Episod { get; set; }
    }
}
