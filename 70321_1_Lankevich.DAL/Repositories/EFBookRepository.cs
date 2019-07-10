using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using _70321_1_Lankevich.DAL.Interfaces;
using _70321_1_Lankevich.DAL.Entities;

namespace _70321_1_Lankevich.DAL.Repositories
{
    public class EFBookRepository : IRepository<Book>
    {
        private ApplicationDbContext context;
        private DbSet<Book> books;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="ctx">Контекст базы данных</param>
        public EFBookRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            books = context.Books;
        }
        public void Create(Book t)
        {
            books.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context
                .Entry(new Book { Id = id })
                .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return books.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return books;
        }

        public Task<Book> GetAsync(int id)
        {
            return books.FindAsync(id);
        }

        public void Update(Book t)
        {
            //если изображение не загружено, то использовать изображение из базы данных
            if (t.Image == null)
            {
                var book = context
                            .Books
                            .AsNoTracking()
                            .Where(d => d.Id == t.Id)
                            .FirstOrDefault();
                t.Image = book.Image;
                t.MimeType = book.MimeType;
            }


            context.Entry<Book>(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
