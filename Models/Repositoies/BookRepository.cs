using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositoies
{
    public class BookRepository : IBookStoreRepository<Book>
    {
        List<Book> books;
        //ctor tap tap to intialize constructor
        public BookRepository()
        {
            books = new List<Book>()
            {
                new Book(){
                   Id=1,Title="C# Programming" ,
                    Description="No Description",
                    ImageUrl="add.jpg",
                    Author=new Author()
                },
                new Book(){
                   Id=2,Title="Java Programming" ,
                    Description="Nothing",
                     ImageUrl="ce.jpg",
                    Author=new Author()
                },
                new Book(){
                   Id=3,Title="Python Programming" ,
                    Description="No Data",
                     ImageUrl="lectures.jpg",
                    Author=new Author()
                }
            };
        }
        public void Add(Book entity)
        {
            entity.Id = books.Max(b=>b.Id)+1;
            books.Add(entity);
        }

        public void Delete(int id)
        {
            var book = Find(id);
            // var book = books.FirstOrDefault(b=>b.Id==id);
            books.Remove(book);
        }

        public Book Find(int id)
        {
            var book = books.SingleOrDefault(b=>b.Id==id);
            return book;

        }

        public IList<Book> List()
        {
            return books;
        }
        public List<Book> Search(string term)
        {
            var results = books.Where(b => b.Title.Contains(term) || b.Description.Contains(term) ||
                b.Author.FullName.Contains(term)).ToList();
            return results;
        }
        public void Update(int id,Book newbook)
        {
            var book = Find(id);
          //  var book = books.FirstOrDefault(b=>b.Id==id);
            book.Title = newbook.Title;
            book.Description = newbook.Description;
            book.Author = newbook.Author;
            book.ImageUrl = newbook.ImageUrl;
        }
    }
}
