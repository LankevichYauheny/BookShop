using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _70321_1_Lankevich.Models
{
    public class PageListViewModel<T> : List<T>
    {

        // Общее количество страниц
        public int TotalPages { get; private set; }


        // Номер текущей страницы
        public int CurrentPage { get; private set; }


        // Конструктор класса
        // <param name="items">Список элементов</param>
        // <param name="current">Номер текущей страницы</param>
        // <param name="total">Общее количество страниц</param>
        private PageListViewModel(List<T> items, int total, int current)
        {
            this.AddRange(items);
            TotalPages = total;
            CurrentPage = current;
        }


        // Создание объекта PageListViewModel
        // </summary>
        // <param name="items">Полный список объектов</param>
        // <param name="current">Номер текущей страницы</param>
        // <param name="pageSize">Количество элементов на странице</param>
        public static PageListViewModel<T> CreatePage(IEnumerable<T> items, int current, int pageSize)
        {
            var totalCount = items.Count();
            var pageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
            var list = items
                        .Skip(pageSize * (current - 1))
                        .Take(pageSize)
                        .ToList();
            return new PageListViewModel<T>(list, pageCount, current);
        }
    }
}