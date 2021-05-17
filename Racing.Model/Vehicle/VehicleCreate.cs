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
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Series { get; set; }
        public int HP { get; set; }
        public decimal Weight { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}