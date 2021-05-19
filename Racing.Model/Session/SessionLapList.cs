using Racing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model.Session
{
    public class SessionLapList
    {
        //public List<Lap> LapList { get; set; }
        public virtual ICollection<Lap> LapList { get; set; }

        public int? AverageLapTime { get; set; }
        public int? BestLapTime { get; set; }
        public int? BestSectorOne { get; set; }
        public int? BestSectorTwo { get; set; }
        public int? BestSectorThree { get; set; }
        public int? OptimalLap { get; set; }
    }
}
