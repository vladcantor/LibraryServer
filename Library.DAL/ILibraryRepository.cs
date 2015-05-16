using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public interface ILibraryRepository
    {
        #region User
        void AddUser(string username, string password, short role);
        Subscriber CheckUser(string username, string password);

        #region Subscriber
        List<Subscriber> ReadAllSubscribers();
        Subscriber FindSubscriberById(int subscriberUid);
        #endregion Subscriber
        #endregion User

        #region Book
        void AddBook(Book book);
        List<Book> ReadAllBooks();
        List<Book> FindByTitle(string title);
        Book FindBookById(int bookId);
        #endregion Book

        #region Rent
        void RentBook(int subscriberUid, int bookUid);
        void ReleaseBook(int subscriberUid, int bookUid);
        #endregion Rent

    }
}
