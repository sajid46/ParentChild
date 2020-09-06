using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DatabaseScaffolding.Models
{
    public class ClassDI:IClassDI
    {
        private PropertyDBEntities db = new PropertyDBEntities();
        public List<vw_AutherBook> Get() 
        {

            vw_AutherBook vw_autherBook;
            List<vw_AutherBook> lst_vw_AutherBooks = new List<vw_AutherBook>();

            var lst = (from a in db.vw_AutherBook select a).ToList();
            foreach (var item in lst)
            {
                vw_autherBook = new vw_AutherBook();
                vw_autherBook.ID = item.ID;
                vw_autherBook.Author = item.Author;
                vw_autherBook.Book = item.Book;
                vw_autherBook.BookID = item.BookID;
                vw_autherBook.Price = item.Price;
                lst_vw_AutherBooks.Add(vw_autherBook);
            }
            return lst_vw_AutherBooks;
        }

    }

    public interface IClassDI
    {
        List<vw_AutherBook> Get();
    }
}