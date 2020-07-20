using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BEL_BookApp;


namespace BooksDetails_DAL
{
    public class BooksDetails_DAL1
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        public Int32 SaveBookDetails(BooksDetails_BEL objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("InsertBookDetails_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookName", objBEL.BookName);
                cmd.Parameters.AddWithValue("@Author", objBEL.Author);
                cmd.Parameters.AddWithValue("@Publisher", objBEL.Publisher);
                cmd.Parameters.AddWithValue("@Price", objBEL.Price);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public DataSet GetBookRecords()
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("FetchBookRecords_Sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                ds.Dispose();
            }
            return ds;
        }

        public Int32 DeleteBookRecord(BooksDetails_BEL objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("DeleteBookRecords_Sp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", objBEL.BookId);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public Int32 UpdateBookRecord(BooksDetails_BEL objBEL)
        {
            int result;
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateBookRecord_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BookId", objBEL.BookId);
                cmd.Parameters.AddWithValue("@BookName", objBEL.BookName);
                cmd.Parameters.AddWithValue("@Author", objBEL.Author);
                cmd.Parameters.AddWithValue("@Publisher", objBEL.Publisher);
                cmd.Parameters.AddWithValue("@Price", objBEL.Price);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

    }
}
