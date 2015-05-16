using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DBManager
    {
        private const string CONNECTION_STRING = "Data Source=VLAD\\VLADSQL;Initial Catalog=lIBRARY;Integrated Security=True;User ID=user;TrustServerCertificate=True";
        /// <summary>
        /// This method is used to execute the neccessary read commands.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="readerToModel"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static List<T> ExecuteReadCommand<T>(string commandText, Func<SqlDataReader, T> readerToModel, params SqlParameter[] commandParameters)
        {
            List<T> readResult = new List<T>(0);
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(commandText, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(commandParameters);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            readResult.Add(readerToModel(sqlDataReader));
                        }
                    }
                }
            }
            return readResult;
        }

        #region Methods
        /// <summary>
        /// Executes the insert, update and delete operation.
        /// </summary>
        /// <param name="commandText">Represents the name of the stored procedure.</param>
        /// <param name="commandParameters">Represents all the neccessary parameters for the stored procedure.</param>
        public static void ExecuteCommand(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, connection, sqlTransaction))
                    {
                        try
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddRange(commandParameters);
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                        }
                        catch (SqlException)
                        {
                            sqlTransaction.Rollback();
                            throw;
                        }
                    }
                }
            }

        }


        /// <summary>
        /// This method is used when desiring to retrieve a single scalar value from the database. It can also get parameteres but it also can reeceive null
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public static object ExecuteScalarCommand<T>(string commandText, params SqlParameter[] commandParameters)
        {

            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(commandText, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (commandParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(commandParameters);
                    }
                    return sqlCommand.ExecuteScalar();
                }
            }

        }
    }
}
     #endregion 