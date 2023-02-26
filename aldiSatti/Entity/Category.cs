using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aldiSatti.Entity
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public List<Product> Products { get; set; }
    }
}