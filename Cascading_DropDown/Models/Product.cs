using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cascading_DropDown.Models
{
    public class Product
    {
        public int pid { get; set; } = 0;

        public string pname { get; set; } = null;

        public int catid { get; set; } = 0;

        public int subcatid { get; set; } = 0;

        public decimal? price { get; set; }

        public int? pqty { get; set; }

        public string catname { get; set; } = null;
        public string subcatname { get; set; } = null;
    }
}
