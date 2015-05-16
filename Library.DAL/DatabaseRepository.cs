using Library.Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class DatabaseRepository : ILibraryRepository
    {
        #region Constants
        const string BOOK_READ_BY_ID = "Book_ReadByUid";
        const string BOOK_READ_BY_TITLE = "Book_ReadBookByTitle";
        const string BOOK_READ_ALL = "ReadAllBooks";
        const string BOOK_INSERT = "Book_Insert";
        const string BOOK_UPDATE = "Book_Update";
        const string SUBSCRIBER_READ_BY_ID = "Subscriber_RedByUid";
        const string SUBSCRIBER_READ_ALL = "ReadAllSubscribers";
        const string USER_AUTHENTICATE = "User_Authenticate";
        const string USER_INSERT = "User_Insert";
        const string RENTEDBOOKS_INSERT = "RentedBooks_Insert";
        const string RENTEDBOOKS_DELETE = "RentedBooks_Delete";

        #endregion Constants

        public void AddUser(string username, string password, short role)
        {
            SqlParameter[] param ={
                new SqlParameter("@Name", SqlDbType.NVarChar, 50){Value=username},
                new SqlParameter("@Role",SqlDbType.SmallInt){Value=role},
                new SqlParameter("@Password",SqlDbType.NVarChar, 50){Value=password},
             };

            DBManager.ExecuteCommand(USER_INSERT, param);
        }

        public Model.Subscriber CheckUser(string username, string password)
        {
            SqlParameter[] param ={
                new SqlParameter("@Name", SqlDbType.NVarChar, 50){Value=username},
                new SqlParameter("@Password",SqlDbType.NVarChar, 50){Value=password}
             };
            return DBManager.ExecuteReadCommand<Model.Subscriber>(USER_AUTHENTICATE, DBUtils.ReaderSubscriberToModel, param).SingleOrDefault();
        }

        public List<Model.Subscriber> ReadAllSubscribers()
        {
            return DBManager.ExecuteReadCommand<Model.Subscriber>(SUBSCRIBER_READ_ALL, DBUtils.ReaderSubscriberToModel);
        }

        public Model.Subscriber FindSubscriberById(int subscriberUid)
        {
            SqlParameter[] param ={
                new SqlParameter("@SubscriberUid", SqlDbType.Int){Value=subscriberUid}
             };
            return DBManager.ExecuteReadCommand<Model.Subscriber>(SUBSCRIBER_READ_BY_ID, DBUtils.ReaderSubscriberToModel, param).SingleOrDefault();
        
        }

        public void AddBook(Model.Book book)
        {
            SqlParameter[] param ={
                new SqlParameter("@Title", SqlDbType.NVarChar, 50){Value=book.Name},
             };

            DBManager.ExecuteCommand(USER_INSERT, param);
        }

        public List<Model.Book> ReadAllBooks()
        {
            return DBManager.ExecuteReadCommand<Model.Book>(BOOK_READ_ALL, DBUtils.ReaderBookToModel);
        }

        public List<Model.Book> FindByTitle(string title)
        {
            SqlParameter[] param ={
                new SqlParameter("@Title", SqlDbType.NVarChar, 50){Value=title},
             };

            return DBManager.ExecuteReadCommand<Model.Book>(BOOK_READ_BY_TITLE, DBUtils.ReaderBookToModel, param);
        }

        public Model.Book FindBookById(int bookUid)
        {
            SqlParameter[] param ={
                new SqlParameter("@BookUid", SqlDbType.Int){Value=bookUid},
             };

            return DBManager.ExecuteReadCommand<Model.Book>(BOOK_READ_BY_ID, DBUtils.ReaderBookToModel, param).SingleOrDefault();
        
        }

        public void RentBook(int subscriberUid, int bookUid)
        {

            SqlParameter[] param ={
                new SqlParameter("@BookUid", SqlDbType.Int){Value=bookUid},
                 new SqlParameter("@SubscriberUid", SqlDbType.Int){Value=subscriberUid},
             };
            DBManager.ExecuteCommand(RENTEDBOOKS_INSERT, param);
        }

        public void ReleaseBook(int subscriberUid, int bookUid)
        {
            SqlParameter[] param ={
                new SqlParameter("@BookUid", SqlDbType.Int){Value=bookUid},
                 new SqlParameter("@SubscriberUid", SqlDbType.Int){Value=subscriberUid},
             };
            DBManager.ExecuteCommand(RENTEDBOOKS_DELETE, param);
        }
    }
}
