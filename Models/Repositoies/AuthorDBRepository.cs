using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositoies
{
    public class AuthorDBRepository : IBookStoreRepository<Author>
    {

        BookstoreDBContext db;
        //ctor tap tap to intialize constructor
        public AuthorDBRepository(BookstoreDBContext _db)
        {
            db = _db;
        }
        public void Add(Author entity)
        {
           
            db.Authors.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var author = Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();

        }

        public Author Find(int id)
        {
            var author = db.Authors.SingleOrDefault(a => a.Id == id);
            return author;

        }

        public IList<Author> List()
        {
            return db.Authors.ToList();
        }

        public List<Author> Search(string term)
        {
            return db.Authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newauthor)
        {
            db.Update(newauthor);
            db.SaveChanges();

        }
    }
}
