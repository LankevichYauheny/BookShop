﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _70321_1_Lankevich.DAL.Entities;
using _70321_1_Lankevich.DAL.Interfaces;

namespace _70321_1_Lankevich.DAL.Repositories
{
    public class FakeRepository : IRepository<Book>
    {
        public void Create(Book t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            return new List<Book>
            {
                new Book {Id=1, Name="Пламя и кровь. Том 1. Кровь драконов", Description="Книга для тех кто очень любит творчество Джорджа Мартина. Книга классная! Если бы Джордж Мартин писал учебники истории, я бы точно поступал на истфак)))", Price =22.49, GenreName="Фантастика" },
                new Book {Id=2, Name="Дневник жены юмориста", Description="Книга-супер!Смешные и непринужденные рассказы о жизни.Читается легко и с улыбкой)", Price =16.78, GenreName="Биографии" },
                new Book {Id=3, Name="Сейлор Мун. Том 1", Description="Это же Легендища!!! Лунная призма, дай мне силу дождаться, пока привезут заказ!!!!!!!!", Price =15.45, GenreName="Комиксы" },
                new Book {Id=4, Name="Атака на титанов. Книга 11", Description="Схватка разведкорпуса с титанами близка к развязке. Эрвин и Армин жертвуют собой, чтобы Леви и Эрен смогли повергнуть противника. Но станет ли победителем тот, кто выиграет это сражение?", Price =19.89, GenreName="Комиксы" },
                new Book {Id=5, Name="Удивительный Человек-Паук. Заговор Клонов", Description="Будучи Человеком-Пауком, Питер Паркер потерял многих - любимых, друзей и даже врагов. Но что случится, если те, по кому он скорбил, вдруг восстанут из могил? Вы узнаете это, когда он встретится с близкими, которых уже и не мечтал увидеть вновь - равно как и с опасными врагами, которых он предпочёл бы считать мёртвыми.", Price =56.53, GenreName="Комиксы" },
                new Book {Id=6, Name="Гарри Поттер и философский камень", Description="На мой взгляд лучшая из всех. Я был еще совсем мелким, когда впервые взял в руки. Перечитатать успел за это время раз 15", Price=20.25, GenreName="Фантастика"},
                new Book {Id=7, Name="Гарри Поттур и Тайная комната", Description="Моя дочь Аня очень мало читает и то по принуждению. Книги о Гарри Потере она просто проглотила на одном дыхании. И с нетерпением ждет следующую. Когда она появится (5-ая книга).Даже нашей бабушке понравилась.Мама Ирина.", Price=20.25, GenreName="Фантастика"},
                new Book {Id=8, Name="Гарри Поттер. Полное собрание (комплект из 7 книг)", Description="\"Гарри Поттер\" - это такая вещь, которая никогда не потеряет своей актуальности.Эти книги написаны очень удачно. В них продуманы все детали, нет ни одного лишнего слова, ни одного лишнего действия!", Price=157.54, GenreName="Фантастика"}
            };
        }

        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book t)
        {
            throw new NotImplementedException();
        }
    }
}
