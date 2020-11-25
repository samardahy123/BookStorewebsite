using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models.Repositoies
{
   public interface IBookStoreRepository<TEntity>
    {
        //list of entities like books
        IList<TEntity> List();
        //search 
        TEntity Find(int Id);
        // insert entity
        void Add(TEntity entity);
        //update entity
        void Update(int id,TEntity entity);
        //delete entity
        void Delete(int Id);
        List<TEntity> Search(string term);

    }
}
