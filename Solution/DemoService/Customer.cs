using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompareUtil {
    public class Customer {

        public int Id { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalDue { get; set; }
        public bool IsPreferredVendor { get; set; }
        public decimal DiscountRate { get; set; }
    }
}
