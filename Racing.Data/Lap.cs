using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Data
{
    public class Lap
    {
        [Key]
        public int LapId { get; set; }
        [ForeignKey(nameof(Session))]
        public int SessionId { get; set; }
        public virtual Session Session { get; set; }
        
        [Range(0,59)]
        public int LapMinutes { get; set; }
        [Range(0,59)]
        public int LapSeconds { get; set; }
        [Range(0,9)]
        public int LapTenthSeconds { get; set; }
        [Range(0,9)]
        public int LapHundrethSeconds { get; set; }
        [Range(0,9)]
        public int LapMilliseconds { get; set; }
        public int LapTime
        {
            get
            {
                int sum = (LapMinutes * 60000) + (LapSeconds * 1000) + (LapTenthSeconds * 100) + (LapHundrethSeconds * 10) + LapMilliseconds;
                return sum;
            }
        }
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
        public int SectorOne {
            get
            {
                int sum = (SectorOneMinutes * 60000) + (SectorOneSeconds * 1000) + (SectorOneTenthSeconds * 100) + (SectorOneHundrethSeconds * 10) + SectorOneMilliseconds;
                return sum;
            } 
        }
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
        public int SectorTwo {
            get
            {
                int sum = (SectorTwoMinutes * 60000) + (SectorTwoSeconds * 1000) + (SectorTwoTenthSeconds * 100) + (SectorTwoHundrethSeconds * 10) + SectorTwoMilliseconds;
                return sum;
            }
        }
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
        public int SectorThree {
            get
            {
                int sum = (SectorThreeMinutes * 60000) + (SectorThreeSeconds * 1000) + (SectorThreeTenthSeconds * 100) + (SectorThreeHundrethSeconds * 10) + SectorThreeMilliseconds;
                return sum;
            }
        }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }
    }
}
