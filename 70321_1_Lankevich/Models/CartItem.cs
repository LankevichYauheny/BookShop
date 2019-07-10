using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _70321_1_Lankevich.DAL.Entities;

namespace _70321_1_Lankevich.Models
{
    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}