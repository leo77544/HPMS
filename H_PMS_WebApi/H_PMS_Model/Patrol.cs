using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PMS_Model
{
    public class Patrol
    {
        public int PatrolId{ get; set; }
        public int EmployeeId { get; set; }
        public string PatrolRport { get; set; }
        public string PatrolArea { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
