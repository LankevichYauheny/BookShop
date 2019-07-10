using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _70321_1_Lankevich.DAL.Entities;


namespace _70321_1_Lankevich.Models
{
    public class Cart
    {
        Dictionary<int, CartItem> cartItems;

        public Cart()
        {
            cartItems = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Добавить корзину
        /// </summary>
        /// <param name="book">объект для добавления</param>
        public void AddItem(Book book)
        {
            if (cartItems.ContainsKey(book.Id))
                cartItems[book.Id].Quantity += 1;
            else
                cartItems.Add(book.Id, new CartItem { Book = book, Quantity = 1 });
        }

        /// <summary>
        /// Удалить из корзины
        /// </summary>
        /// <param name="book">Объект для удаления</param>
        public void RemoteItem(Book book)
        {
            if (cartItems.ContainsKey(book.Id))
            {
                if (cartItems[book.Id].Quantity == 1)
                    cartItems.Remove(book.Id);
                else
                    cartItems[book.Id].Quantity -= 1;
            }
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }


        /// <summary>
        /// Получение среднего значения Price 
        /// </summary>
        /// <returns></returns>
        public double GetAvarege()
        {
            if (cartItems.Count == 0) return 0;
            double avarege = cartItems
                                .Values
                                .Sum(i => i.Book.Price * i.Quantity) / cartItems.Values.Sum(i => i.Quantity);
            return Math.Round(avarege, 2);
        }

        public IEnumerable<CartItem> GetItems()
        {
            return cartItems.Values;
        }


        /// <summary>
        /// Количество элемента с указаным ID в корзине
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountItem(int id)
        {
            if (cartItems.ContainsKey(id))
                return cartItems[id].Quantity;
            else
                return 0;
        }
    }
}