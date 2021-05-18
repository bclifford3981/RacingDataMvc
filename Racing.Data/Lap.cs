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
        [Required]
        public int LapTime { get; set; }
        public int SectorOne { get; set; }
        public int SectorTwo { get; set; }
        public int SectorThree { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }
    }
}
