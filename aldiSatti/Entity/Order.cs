using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aldiSatti.Entity
{
    public class Order
    {
        public int id { get; set; }
        public string orderNumber { get; set; }
        public double total { get; set; }
        public DateTime orderDate { get; set; }
        public OrderState orderState { get; set; }
        public string userName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string quarter { get; set; }
        public string postCode { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public virtual Order Order { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public int productId { get; set; }
        public virtual Product Product { get; set; }
    }
}