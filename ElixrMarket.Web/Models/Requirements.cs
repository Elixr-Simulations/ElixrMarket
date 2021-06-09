using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElixrMarket.Web.Models
{
    public class Requirements
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string OS { get; set; }
        public string Storage { get; set; }
        public string MinProc { get; set; }
        public string RecProc { get; set; }
        public string MinMem { get; set; }
        public string RecMem { get; set; }
        public string MinGraph { get; set; }
        public string RecGraph { get; set; }
    }
}
