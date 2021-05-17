using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Data
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [Range(2,20)]
        public string Name { get; set; }
        [Required]
        [Range(2,40)]
        public string Class { get; set; }
        [Required]
        [Range(2,40)]
        public string Series { get; set; }
        public int HP { get; set; }
        public decimal Weight { get; set; }
        [DefaultValue(false)]
        public bool IsStarred { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public Guid OwnerId { get; set; }


    }
}
