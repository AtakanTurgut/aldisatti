using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aldiSatti.Models
{
    public class StatsModel
    {
        public int numberOfProducts { get; set; }
        public int numberOfOrders{ get; set; }
        public int numberOfPendingOrders { get; set; }
        public int numberOfPackedOrders { get; set; }
        public int numberOfShippingOrders { get; set; }
        public int numberOfCompletedOrders { get; set; }
    }
}