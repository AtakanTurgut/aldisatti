using aldiSatti.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aldiSatti.Models
{
    public class AdminOrder
    {
        public int id { get; set; }
        public string orderNumber { get; set; }
        public double total { get; set; }
        public DateTime orderDate { get; set; }
        public OrderState orderState { get; set; }
        public int count { get; set; }
    }
}