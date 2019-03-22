using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_PMS_Model
{
    public class PageList
    {
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public List<DataMoney> list { get; set; }
    }
}
