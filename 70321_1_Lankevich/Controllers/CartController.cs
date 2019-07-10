using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _70321_1_Lankevich.DAL.Entities;
using _70321_1_Lankevich.DAL.Interfaces;
using _70321_1_Lankevich.Models;

namespace _70321_1_Lankevich.Controllers
{
    public class CartController : Controller
    {
        IRepository<Book> repository;

        public CartController(IRepository<Book> repo)
        {
            repository = repo;
        }

        [Authorize]
        // GET: Cart
        public ActionResult Index(string returnUrl, Cart cart)
        {
            TempData["returnUrl"] = returnUrl;
            //return View(GetCart());
            return View(cart);
        }

        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = Session["cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["cart"] = cart;
            }
            return cart;
        }

        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
            {
                GetCart().AddItem(item);
                TempData["MessageCart"] = string.Format("Успешно добавлен элемент: {0}", item.Name);
            }
            else
            {
                TempData["MessageCart"] = "Элемент не был добавлен";
            }

            return Redirect(returnUrl);

        }

        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }

        [HttpPost]
        public JsonResult DeleteFromCart(int id)
        {
            Book book = repository.Get(id);

            if (book != null)
            {
                Cart cart = GetCart();
                cart.RemoteItem(book);

                //ViewBag.MessageCart = string.Format("Успешно удален элемент: {0}", book.Name);

                var r = new { result = true, cartId = id, quantity = cart.CountItem(id), avarege = cart.GetAvarege(), message = string.Format("Успешно удален элемент: {0}", book.Name) };
                return Json(r);
            }

            return Json(new { result = false, message = "Элемент не был удален" });
        }
    }
}