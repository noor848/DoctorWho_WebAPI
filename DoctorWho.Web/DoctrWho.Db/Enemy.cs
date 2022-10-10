using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfDoctorWho
{
    public class Enemy
    {
        public int Id { get; set; }
        public string EnemyName { get; set; }
        public string Description { get; set; }
        public ICollection<Episod> Episod { get; set; }
    }
}
