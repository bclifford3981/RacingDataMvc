using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Model.Session
{
    public class SessionCreate
    {
        public int SessionId { get; set; }
        public string Track { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
