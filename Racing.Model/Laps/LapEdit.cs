using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model.Laps
{
    public class LapEdit
    {
        public int LapId { get; set; }
        public int SessionId { get; set; }
        public int LapMinutes { get; set; }
        [Range(0, 59)]
        public int LapSeconds { get; set; }
        [Range(0, 9)]
        public int LapTenthSeconds { get; set; }
        [Range(0, 9)]
        public int LapHundrethSeconds { get; set; }
        [Range(0, 9)]
        public int LapMilliseconds { get; set; }
        [Range(0, 59)]
        public int SectorOneMinutes { get; set; }
        [Range(0, 59)]
        public int SectorOneSeconds { get; set; }
        [Range(0, 9)]
        public int SectorOneTenthSeconds { get; set; }
        [Range(0, 9)]
        public int SectorOneHundrethSeconds { get; set; }
        [Range(0, 9)]
        public int SectorOneMilliseconds { get; set; }
        [Range(0, 59)]
        public int SectorTwoMinutes { get; set; }
        [Range(0, 59)]
        public int SectorTwoSeconds { get; set; }
        [Range(0, 9)]
        public int SectorTwoTenthSeconds { get; set; }
        [Range(0, 9)]
        public int SectorTwoHundrethSeconds { get; set; }
        [Range(0, 9)]
        public int SectorTwoMilliseconds { get; set; }
        [Range(0, 59)]
        public int SectorThreeMinutes { get; set; }
        [Range(0, 59)]
        public int SectorThreeSeconds { get; set; }
        [Range(0, 9)]
        public int SectorThreeTenthSeconds { get; set; }
        [Range(0, 9)]
        public int SectorThreeHundrethSeconds { get; set; }
        [Range(0, 9)]
        public int SectorThreeMilliseconds { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
