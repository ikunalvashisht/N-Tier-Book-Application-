using System;
using System.Data;
using BEL_BookApp;
using BooksDetails_DAL;


namespace BLL_BookApp
{
    public class BookDetails_BLL
    {

        public Int32 SaveBookDetails(BooksDetails_BEL objBel)
        {
            BooksDetails_DAL1 objDal = new BooksDetails_DAL1();
            try
            {
                return objDal.SaveBookDetails(objBel);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objDal = null;
            }
        }

        public DataSet GetBookRecords()
        {
            BooksDetails_DAL1 objDal = new BooksDetails_DAL1();
            try
            {
                return objDal.GetBookRecords();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 DeleteBookRecord(BooksDetails_BEL objBel)
        {
            BooksDetails_DAL1 objDal = new BooksDetails_DAL1();
            try
            {
                return objDal.DeleteBookRecord(objBel);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objDal = null;
            }
        }

        public Int32 UpdateBookRecord(BooksDetails_BEL objBel)
        {
            BooksDetails_DAL1 objDal = new BooksDetails_DAL1();
            try
            {
                return objDal.UpdateBookRecord(objBel);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                objDal = null;
            }
        }

    }
}
