using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model.Vehicle
{
    public class VehicleList
    {
        public int VehicleId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        //[UIHint("Starred")]
        //public bool? IsStarred { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

    }
}
