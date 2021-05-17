using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Data
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        [ForeignKey(nameof(Vehicle))]
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        [Required]
        public string Track { get; set; }
        public ICollection<Lap> LapList { get; set; }
        public int AverageLapTime
        {
            get
            {
                int total = 0;
                foreach (Lap lap in LapList)
                {
                    total += lap.LapTime;
                }
                int solve = total / LapList.Count();
                return solve;
            }
        }
        public int BestLapTime
        {
            get
            {
                int search = 0;
                foreach (Lap lap in LapList)
                {
                    if (search == 0)
                    {
                        search = lap.LapTime;

                    }
                    if (search > lap.LapTime)
                    {
                        search = lap.LapTime;
                    }
                }
                return search;
            }
        }
        public int BestSectorOne
        {
            get
            {
                int search = 0;
                foreach (Lap lap in LapList)
                {
                    if (search == 0)
                    {
                        search = lap.SectorOne;
                    }
                    if (search > lap.SectorOne)
                    {
                        search = lap.SectorOne;
                    }
                }
                return search;
            }
        }
        public int BestSectorTwo
        {
            get
            {
                int search = 0;
                foreach (Lap lap in LapList)
                {
                    if (search == 0)
                    {
                        search = lap.SectorTwo;
                    }
                    if (search > lap.SectorTwo)
                    {
                        search = lap.SectorTwo;
                    }
                }
                return search;
            }
        }
        public int BestSectorThree
        {
            get
            {
                int search = 0;
                foreach (Lap lap in LapList)
                {
                    if (search == 0)
                    {
                        search = lap.SectorThree;
                    }
                    if (search > lap.SectorThree)
                    {
                        search = lap.SectorThree;
                    }
                }
                return search;
            }
        }
        public int OptimalLap
        {
            get
            {
                int opt = BestSectorOne + BestSectorTwo + BestSectorThree;
                return opt;
            }
        }

        //public TempData AvgAirTemp { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }

    }
}
