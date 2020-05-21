using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADODotNetDemoCode
{
    public partial class SaveProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // When the page loads for the first time
            if (!IsPostBack)
            {
                // The session value would be set if and only if the Edit button in gridview in View Products page is clicked
                if (Session["ProId"] != null)
                {
                    BindFormDetails();
                }
            }

        }

        /// <summary>
        /// The below method would be used to bind the form details.
        /// </summary>
        private void BindFormDetails()
        {
            ViewState["ProId"] = Session["ProId"];
            Session.Clear();
            DBClass objDb = new DBClass();
            DataSet ds = new DataSet();
            ds = objDb.ViewProductByID(Convert.ToInt32(ViewState["ProId"]));
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    lbProductID.Text = Convert.ToString(ViewState["ProId"]);
                    tbProductName.Text = Convert.ToString(ds.Tables[0].Rows[0]["ProductName"]);
                    tbRate.Text = Convert.ToString(ds.Tables[0].Rows[0]["Rate"]);
                    tbQuantity.Text = Convert.ToString(ds.Tables[0].Rows[0]["Quantity"]);
                }
            }

        }

        /// <summary>
        /// The below method is used to save the product details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Product objProduct = new Product();
            DBClass objDb = new DBClass();
            if (ViewState["ProId"] != null) objProduct.ProductId = Convert.ToInt32(ViewState["ProId"]);
            objProduct.ProductName = tbProductName.Text;
            objProduct.Rate = Convert.ToDouble(tbRate.Text);
            objProduct.Quantity = Convert.ToInt32(tbQuantity.Text);
            int proId = objDb.SaveDetails(objProduct);
            lbProductID.Text = Convert.ToString(proId);
        }

        /// <summary>
        /// The below method is used to reset the form values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaveProduct.aspx");
        }
    }
}