using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cascading_DropDown.Models
{
    public class Product
    {
        [Key]
        public int pid { get; set; } = 0;

        public string pname { get; set; } = null;

        public int catid { get; set; } = 0;

        public int subcatid { get; set; } = 0;

        public decimal? price { get; set; }

        public int? pqty { get; set; }

        [NotMapped]
        public string catname { get; set; } = null;

        [NotMapped]
        public string subcatname { get; set; } = null;
    }
    public class Category
    {
        [Key]
        public int catid { get; set; } = 0;
        public string catname { get; set; } = null;
    }
    public class SubCategory
    {
        [Key]
        public int subcatid { get; set; } = 0;
        public int catid { get; set; } = 0;
        public string subcatname { get; set; } = null;
    }
    
}
