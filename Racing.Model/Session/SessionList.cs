using Racing.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model.Session
{
    public class SessionList
    {
        public int SessionId { get; set; }
        public string Track { get; set; }
        public int VehicleId { get; set; }
        public List<Lap> LapList { get; set; }
        public int? AverageLapTime { get; set; }
        public int? BestLapTime { get; set; }
        public int? BestSectorOne { get; set; }
        public int? BestSectorTwo { get; set; }
        public int? BestSectorThree { get; set; }
        public int? OptimalLap { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

    }
}
