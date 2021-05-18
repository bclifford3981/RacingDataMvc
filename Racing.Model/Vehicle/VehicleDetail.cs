using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model.Vehicle
{
    public class VehicleDetail
    {
        
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Series { get; set; }
        public double HP { get; set; }
        public decimal Weight { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
