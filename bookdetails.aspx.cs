using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEL_BookApp;
using BLL_BookApp;

namespace Employee_N_Tier
{
    public partial class bookdetails : System.Web.UI.Page
    {

        #region "Create and Initialize objects "
        BooksDetails_BEL objBookDetailsBEL = new BooksDetails_BEL();
        BookDetails_BLL objBookDetailsBLL = new BookDetails_BLL();
        #endregion

        #region "Bind Book Records on Page load Event"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindBookRecordsGridView();
            }
        }
        #endregion

        #region "Save Book Record"
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objBookDetailsBEL.BookName = txtBookName.Text.Trim();
            objBookDetailsBEL.Author = txtAuthor.Text.Trim();
            objBookDetailsBEL.Publisher = txtPublisher.Text.Trim();
            objBookDetailsBEL.Price = Convert.ToDecimal(txtPrice.Text);
            try
            {
                int retVal = objBookDetailsBLL.SaveBookDetails(objBookDetailsBEL);
                if (retVal > 0)
                {
                    lblStatus.Text = "Book detail saved successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    ClearControls();
                    BindBookRecordsGridView();
                }
                else
                {
                    lblStatus.Text = "Book details couldn't be saved";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }
        }
        #endregion

        #region "Bind Book Records in GridView"
        private void BindBookRecordsGridView()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = objBookDetailsBLL.GetBookRecords();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    grdBookDetails.DataSource = ds;
                    grdBookDetails.DataBind();
                }
                else
                {
                    grdBookDetails.DataSource = null;
                    grdBookDetails.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }
        }
        #endregion

        #region "Edit and update Book Records"
        protected void grdBookDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdBookDetails.EditIndex = e.NewEditIndex;
            BindBookRecordsGridView();
        }

        protected void grdBookDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdBookDetails.EditIndex = -1;
            BindBookRecordsGridView();
        }

        protected void grdBookDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objBookDetailsBEL.BookId = Convert.ToInt32(grdBookDetails.DataKeys[e.RowIndex].Value);
            objBookDetailsBEL.BookName = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtBookNameEdit"))).Text.Trim();
            objBookDetailsBEL.Author = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtAuthorEdit"))).Text.Trim();
            objBookDetailsBEL.Publisher = ((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtPublisherEdit"))).Text.Trim();
            objBookDetailsBEL.Price = Convert.ToDecimal(((TextBox)(grdBookDetails.Rows[e.RowIndex].FindControl("txtPriceEdit"))).Text.Trim());
            try
            {
                int retVal = objBookDetailsBLL.UpdateBookRecord(objBookDetailsBEL);
                if (retVal > 0)
                {
                    lblStatus.Text = "Book detail updated successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    ClearControls();
                    grdBookDetails.EditIndex = -1;
                    BindBookRecordsGridView();
                }
                else
                {
                    lblStatus.Text = "Book details couldn't be updated";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }
        }
        #endregion

        #region "Delete Book Record"
        protected void grdBookDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Book_Id = Convert.ToInt32(grdBookDetails.DataKeys[e.RowIndex].Value);
            objBookDetailsBEL.BookId = Book_Id;
            try
            {
                int retVal = objBookDetailsBLL.DeleteBookRecord(objBookDetailsBEL);

                if (retVal > 0)
                {
                    lblStatus.Text = "Book detail deleted successfully";
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    ClearControls();
                    BindBookRecordsGridView();
                }
                else
                {
                    lblStatus.Text = "Book details couldn't be deleted";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                Response.Write("Oops! error occured :" + ex.Message.ToString());
            }
            finally
            {
                objBookDetailsBEL = null;
                objBookDetailsBLL = null;
            }
        }
        #endregion

        #region "Paging in GridView"
        protected void grdBookDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdBookDetails.PageIndex = e.NewPageIndex;
            BindBookRecordsGridView();
        }
        #endregion

        #region "Clear/Reset controls "
        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
        private void ClearControls()
        {
            txtBookName.Text = string.Empty;
            txtAuthor.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtBookName.Focus();
        }
        #endregion      

    }
}