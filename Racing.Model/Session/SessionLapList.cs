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
        public int SessionId { get; set; }
        public virtual ICollection<Lap> LapList { get; set; }
        public virtual List<Lap> SessionLaps { get; set; }

        public string AverageLapTime { get; set; }
        public string BestLapTime { get; set; }
        public string BestSectorOne { get; set; }
        public string BestSectorTwo { get; set; }
        public string BestSectorThree { get; set; }
        public string OptimalLap { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
