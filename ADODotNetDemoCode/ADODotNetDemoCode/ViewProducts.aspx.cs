using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADODotNetDemoCode
{
    public partial class ViewProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }  
        }

        /// <summary>
        /// The below method is used to bind the gridview details
        /// </summary>
        private void BindGrid()
        {
            DataSet ds = new DataSet();
            DBClass objDb  = new DBClass();
            ds = objDb.ViewProducts();
            gvProductDetails.DataSource = ds;
            gvProductDetails.DataBind();
        }

        /// <summary>
        /// The below method is a gridview event and would be used to work on data rows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProductDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // COde when Edit button id clicked
            if (e.CommandName == "cmdEdit")
            {
                // Taking a session variable and storing the Product Id (which is unique)
                Session["ProId"] = e.CommandArgument;
                // Redirecting the user to the Save Product page which wouyld be used to edit the product details
                Response.Redirect("SaveProduct.aspx");
            }
            else if (e.CommandName == "cmdDelete")
            {
                DBClass objDb = new DBClass();
                int noOfRows = 0;
                string confirmValue = Request.Form["confirm_value"];
                if (confirmValue == "Yes")
                {
                    noOfRows = objDb.DeleteProduct(Convert.ToInt32(e.CommandArgument));
                }
                if (noOfRows > 0)
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Successfully deleted')", true);
                    BindGrid();
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error')", true);
                }
            }
        }
    }
}