using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PMS_Model
{
    public class Visitor
    {
        public int Visitorid { get; set; }
        public string VisitorName { get; set; }
        public string HostName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
