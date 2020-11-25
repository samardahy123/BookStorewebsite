using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositoies
{
    public class AuthorRepository : IBookStoreRepository<Author>
    {
        List<Author> authors;
        //ctor tap tap to intialize constructor
        public AuthorRepository()
        {
            authors = new List<Author>()
            {
                new Author(){Id=1,FullName="Khalid Elsadany"},
                new Author(){Id=2,FullName="Hamid "},
                 new Author(){Id=3,FullName="Said"}
            };
        }
        public void Add(Author entity)
        {
            entity.Id = authors.Max(b => b.Id) + 1;
            authors.Add(entity);
        }

        public void Delete(int id)
        {
            var author = Find(id);
            authors.Remove(author);

        }

        public Author Find(int id)
        {
              var author = authors.SingleOrDefault(a => a.Id == id);
            return author;
            
        }

        public IList<Author> List()
        {
            return authors;
        }

        public List<Author> Search(string term)
        {
            return authors.Where(a => a.FullName.Contains(term)).ToList();
        }

        public void Update(int id, Author newauthor)
        {
           var author= Find(id);
            author.FullName = newauthor.FullName;

        }
    }
}
