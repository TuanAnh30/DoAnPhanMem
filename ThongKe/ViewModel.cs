using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin.Models
{
    public class ViewModel
    {
        public string NamePro { get; set; }
        public string DesPro { get; set; }
        public string ImgPro { get; set; }
        public decimal pricePro { get; set; }
        public string chude { get; set; }

        [System.ComponentModel.DataAnnotations.Key]
        public int? IDpro { get; set; }
        public decimal Total_money { get; set; }
        public SACH product { get; set; }
        public CHUDE Chude { get; set; }
        public CTDATHANG orderdetail    { get; set; }
        public IEnumerable<SACH> productlist { get; set; }
        public int? Top3_Quantity { get; set; }
        public int? sum_Quantity { get; set; }
    }
}