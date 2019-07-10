using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _70321_1_Lankevich.DAL.Entities
{
    public class Book
    {
        [HiddenInput]
        public int Id { get; set; } // id блюда

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название книги")]
        public string Name { get; set; } // название книги
        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; } // описание книги
        [Required]
        [Display(Name = "Цена")]
        public double Price { get; set; } // цена книги
        [Required]
        [Display(Name = "Жанр")]
        public string GenreName { get; set; } // жанр книги
        public byte[] Image { get; set; } // данные изображения
        public string MimeType { get; set; } // Mime - тип данных изображения
    }
}
