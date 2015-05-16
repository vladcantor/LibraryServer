using Library.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL
{
    public class DBUtils
    {
        public static Subscriber ReaderSubscriberToModel(SqlDataReader reader)
        { 
            return new Subscriber{
                Id =  reader.GetInt32(reader.GetOrdinal("UserUid")),
                Name = reader.GetString(reader.GetOrdinal("Name"))
            };
        }

        public static Book ReaderBookToModel(SqlDataReader reader)
        {
            return new Book {
                Id = reader.GetInt32(reader.GetOrdinal("BookUid")),
                Name = reader.GetString(reader.GetOrdinal("Title")),
                IsRented = reader.GetBoolean(reader.GetOrdinal("IsRented"))
            };
        }
    }
}
