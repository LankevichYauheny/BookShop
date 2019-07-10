using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using _70321_1_Lankevich.Models;
using _70321_1_Lankevich.DAL.Entities;
using _70321_1_Lankevich.DAL.Interfaces;

namespace _70321_1_Lankevich.Controllers
{
    public class MenuController : Controller
    {
        List<MenuItem> items;
        IRepository<Book> repository;
        public MenuController(IRepository<Book> repo)
        {
            repository = repo;

            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home", Action="Index", Active=string.Empty},
                new MenuItem{Name="Каталог Книг", Controller="Book", Action="List", Active=string.Empty},
                new MenuItem{Name="Администрирование", Controller="Admin", Action="Index", Active=string.Empty}
            };
        }

        /*
            Методы «Main», «UserInfo», «Side» и «Map» должны возвращать частичные представления главного меню, 
            меню пользователя (регистрация и вход), меню в левой колонке и карту сайта соответственно.  Вызов 
            частичных представлений осуществлять с помощью расширяющего метода @Html.Action, так как частичное 
            представление возвращается методом контроллера. 
         */
        [ChildActionOnly]
        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            items.First(m => m.Controller == c)
                .Active = "active";
            return PartialView(items);
        }

        [ChildActionOnly]
        public PartialViewResult UserInfo()
        {

            return PartialView();
        }

        [ChildActionOnly]
        public PartialViewResult Side()
        {
            var genres = repository
                        .GetAll()
                        .Select(d => d.GenreName)
                        .Distinct();
            return PartialView(genres);
        }

        [ChildActionOnly]
        public PartialViewResult Map()
        {
            return PartialView(items);
        }

        
    }
}