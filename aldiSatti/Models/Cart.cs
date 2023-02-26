using aldiSatti.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aldiSatti.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }

        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.product.id == product.id);

            if (line == null)
            {
                _cartLines.Add(new CartLine() { product = product, quantity = quantity });
            }
            else
            {
                line.quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cartLines.RemoveAll(i => i.product.id == product.id);
        }

        public void ClearCart()
        {
            _cartLines.Clear();
        }

        public double Total()
        {
            return _cartLines.Sum(i => i.product.price * i.quantity);
        }
    }

    public class CartLine
    {
        public Product product { get; set; }
        public int quantity { get; set; }
    }
}