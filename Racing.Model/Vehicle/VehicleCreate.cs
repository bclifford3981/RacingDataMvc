using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model
{
    public class VehicleCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Class { get; set; }
        [Required]
        public string Series { get; set; }
        public double HP { get; set; }
        public decimal Weight { get; set; }
        
    }
}