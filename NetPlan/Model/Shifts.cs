using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPlan.Model
{
    class Shifts
    {
        public int id { get; set; }
        public DateTime? date { get; set; }
        public int? fk_workhourTemplate { get; set; }
        public int? fk_users { get; set; }
    }
}
