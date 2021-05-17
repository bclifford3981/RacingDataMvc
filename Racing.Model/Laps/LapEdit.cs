using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model.Laps
{
    public class LapEdit
    {
        public int LapId { get; set; }
        public int SessionId { get; set; }
        public int LapTime { get; set; }
        public int SectorOne { get; set; }
        public int SectorTwo { get; set; }
        public int SectorThree { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
