using netmvc_relatable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace netmvc_relatable.Controllers
{
    public class ShoppingCartsController : Controller
    {
        // GET: ShoppingCarts
       
        private static string SHOPPING_CART_NAME = "shoppingCart";
        private MyContext db = new MyContext();

        public ActionResult AddCart(int productId, int quantity)
        {
            if (quantity <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid Quantity");
            }
            var product = db.Products.Find(productId);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product's' not found");
            }

            var sc = LoadShoppingCart();
            sc.AddCart(product, quantity);   
            SaveShoppingCart(sc);
            return Redirect("/ShoppingCarts/ShowCart");
        }

        public ActionResult ShowCart()
        {
            var shoppingCart = LoadShoppingCart();
            ViewBag.shoppingCart = shoppingCart;
            return View();
        }
        public ActionResult CreateOrder()
        {
            var shoppingCart = LoadShoppingCart();
            if (shoppingCart == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Bad Request");
            }
            var transaction = db.Database.BeginTransaction();
            try
            {
                var order = new Order()
                {
                    MemberID = 1,
                    PaymentTypeID = (int)Order.PaymentType.Cod,
                    ShipName = "mai",
                    ShipAddress = "ha noi",
                    ShipPhone = "123456789",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now.Millisecond,
                    DeletedAt = DateTime.Now.Millisecond,
                    Status = (int)Order.OrderStatusType.Pending,
                    TotalPrice = shoppingCart.GetTotalPrice(),
                    OrderDetails = new List<OrderDetail>()
                };   
                foreach (var item in shoppingCart.GetCartItems())
                {
                    var orderDetail = new OrderDetail()
                    {
                        OrderID = order.ID,
                        ProductID = item.Value.ProductID,
                        Quantity = item.Value.Quantity,
                        UnitPrice = item.Value.UnitPrice
                    };
                    order.OrderDetails.Add(orderDetail);
                }
                db.Orders.Add(order);
                db.SaveChanges();
                transaction.Commit();
                ClearShoppingCart();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                transaction.Rollback();
            }
            return Redirect("/Orders");
        }

        public ActionResult ShowOrder()
        {
            var order = db.Orders.ToList();
            return View("AddCart");
        }
        private void ClearShoppingCart()
        {
            Session.Remove(SHOPPING_CART_NAME);
        }

        private void SaveShoppingCart(ShoppingCart shoppingCart)
        {
            Session[SHOPPING_CART_NAME] = shoppingCart;
        }

        private ShoppingCart LoadShoppingCart()
        {
            // lấy thông tin giỏ hàng ra.
            var sc = Session[SHOPPING_CART_NAME] as ShoppingCart;
            if (sc == null)
            {
                sc = new ShoppingCart();
            }
            return sc;
        }
    }
}