/*
    Данный класс описывает параметры для ссылок главного меню и карты сайта: 
    - Текст надписи; 
    - Имя контроллера; 
    - Имя метода; 
    - Текущий (активный) пункт.  
 */


namespace _70321_1_Lankevich.Models
{
    public class MenuItem
    {
        public string Name { set; get; }        // Текст надписи         
        public string Controller { set; get; }  // Имя контроллера         
        public string Action { set; get; }      // Имя метода         
        public string Active { set; get; }      // Текущий пункт
    }
}