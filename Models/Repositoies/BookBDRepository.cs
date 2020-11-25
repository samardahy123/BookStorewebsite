using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositoies
{
    public class BookBDRepository : IBookStoreRepository<Book>
    {
        BookstoreDBContext db;
        //ctor tap tap to intialize constructor
        public BookBDRepository(BookstoreDBContext _db)
        {

            db = _db;
        }
        public void Add(Book entity)
        {
           
          db.Books.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = Find(id);
            // var book = books.FirstOrDefault(b=>b.Id==id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public Book Find(int id)
        {
            var book = db.Books.Include(a => a.Author).SingleOrDefault(b => b.Id == id);
            return book;

        }

        public IList<Book> List()
        {
            return db.Books.Include(a=>a.Author).ToList();
        }

        public void Update(int id, Book newbook)
        {
            db.Update(newbook);
            db.SaveChanges();
        }
        public List<Book> Search(string term) {
            var results = db.Books.Include(a => a.Author).
                Where(b => b.Title.Contains(term)||b.Description.Contains(term)||
                b.Author.FullName.Contains(term)).ToList();
            return results;
        }
    }
}
