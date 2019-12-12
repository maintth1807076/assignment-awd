using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace netmvc_relatable.Models
{
    public class ShoppingCart
    {
        private Dictionary<int, CartItem> _cartItems = new Dictionary<int, CartItem>();
        private double _totalPrice;

        public Dictionary<int, CartItem> GetCartItems()
        {
            return _cartItems;
        }
        public void SetCartItems(Dictionary<int, CartItem> cartItems)
        {
            this._cartItems = cartItems;
        }
        public double GetTotalPrice()
        {
            _totalPrice = 0;
            foreach(var item in _cartItems.Values)
            {
                _totalPrice += item.UnitPrice * item.Quantity;
            }
            return this._totalPrice;
        }
        public void AddCart(Product product, int quantity)
        {
            if (_cartItems.ContainsKey(product.ID))
            {
                var item = _cartItems[product.ID];
                item.Quantity += quantity;
                _cartItems[product.ID] = item;
                return;
            }
            var cartItem = new CartItem
            {
                ProductID = product.ID,
                ProductName = product.Name,
                UnitPrice = product.Price,
                Quantity = quantity
            };
            _cartItems.Add(product.ID, cartItem);
        }
        public void RemoveCart()
        {

        }
    }
}