using aldiSatti.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aldiSatti.Models
{
    public class OrderDetails
    {
        public int orderId { get; set; }
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
        public virtual List<OrderLineModel> OrderLines { get; set; }
    }

    public class OrderLineModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string image { get; set; }
    }
}