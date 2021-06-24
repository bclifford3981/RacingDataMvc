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
        //[ForeignKey(nameof(Lap))]
        //public int LapId { get; set; }
        //public virtual Lap Lap { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        [Required]
        public string Track { get; set; }
        //public int FakeSessionId { get
        //    { };
        // Return List of all laps in database

        public virtual List<Lap> LapList { get; set; }

        public string AverageLapTime
        {
            get
            {
                int solve = 0;
                int total = 0;
                foreach (Lap lap in LapList)
                {
                    total += lap.LapTime;
                }

                if (LapList.Count == 0)
                {
                    solve = 0;
                    return "0";
                }
                solve = total / LapList.Count();
                return Convert.ToString(solve);
            }
        }

        public string BestLapTime
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
                return Convert.ToString(search);
            }
        }
        public string BestSectorOne
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
                return Convert.ToString(search);
            }

        }
        public string BestSectorTwo
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
                return Convert.ToString(search);
            }

        }
        public string BestSectorThree
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
                return Convert.ToString(search);
            }

        }
        public string OptimalLap
        {
            get
            {
                int opt = Convert.ToInt32(BestSectorOne) + Convert.ToInt32(BestSectorTwo) + Convert.ToInt32(BestSectorThree);
                return Convert.ToString(opt);
            }

        }

            //public TempData AvgAirTemp { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }
        

    }
}
