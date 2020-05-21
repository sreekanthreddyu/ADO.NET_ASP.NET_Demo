using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Before using System.Configuration, Go to solution explorer. In your project -> References (Right Click) -> Add refererence -> Assesmblies -> Check mark System.Configuration
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADODotNetDemoCode
{
    public class DBClass
    {
        SqlConnection con;
        string conString;
        SqlCommand cmd;

        /// <summary>
        /// The below method is used for establishing the connection with the database
        /// The connection string is set, connection object is created, SQL command object is created for this particular connection.
        /// </summary>
        void Connection()
        {
            conString = System.Configuration.ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
            con = new SqlConnection(conString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        /// <summary>
        /// The below method is used for both Insert and Update operation
        /// The method saves/updates the details in the database
        /// </summary>
        /// <param name="objProduct">The method takes the input as an object of the Product class</param>
        /// <returns>Product ID that would be either set to newly generated ID, existinng ID or -1</returns>
        public int SaveDetails(Product objProduct)
        {
            // Calling the connection method
            Connection();
            // Assigning the command name for the SQL Command as the stored procedure name which is to be executed
            cmd.CommandText = "usp_SAVE_tbl_Products_PG_ADODotNetDemoCode";
            // Givinng the command type as stored procedure else the above text would be considered as a query
            cmd.CommandType = CommandType.StoredProcedure;
            // Adding parameters which are expected by the stored procedure
            cmd.Parameters.AddWithValue("@ProID",objProduct.ProductId);
            cmd.Parameters.AddWithValue("@ProductName",objProduct.ProductName);
            cmd.Parameters.AddWithValue("@Rate",objProduct.Rate);
            cmd.Parameters.AddWithValue("@Quantity",objProduct.Quantity);
            // Taking an SQL Parameter which would fetch the out parameter returned by the Store Procedure
            SqlParameter productID = new SqlParameter("@ProductID", SqlDbType.Int);
            productID.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(productID);
            // Opening the connection
            con.Open();
            // Executing the non query would return the number of rows affected
            int noOfRows = cmd.ExecuteNonQuery();
            // Closing the coonection
            con.Close();

            // If any rows got affected fetching that Product ID
            if (noOfRows > 0)
                objProduct.ProductId = Convert.ToInt32(cmd.Parameters["@ProductID"].Value);
            // Else if no rwos got affected then the operation failed and -1 is returned.
            else
                objProduct.ProductId = -1;
            // Returning the Product ID
            return objProduct.ProductId;
        }

        /// <summary>
        /// The below method is to delete the product for the database
        /// </summary>
        /// <param name="productId">Contains Product id which would be unique</param>
        /// <returns>Number of rows affected in the database</returns>
        public int DeleteProduct(int productId)
        {
            // Calling the connection method
            Connection();
            // Assigning the command name for the SQL Command as the stored procedure name which is to be executed
            cmd.CommandText = "usp_Delete_tbl_Products_PG_ADODotNetDemoCode";
            // Givinng the command type as stored procedure else the above text would be considered as a query
            cmd.CommandType = CommandType.StoredProcedure;
            // Adding parameters which are expected by the stored procedure
            cmd.Parameters.AddWithValue("@ProID", productId);
            // Opening the connection
            con.Open();
            // Executing the non query would return the number of rows affected
            int noOfRows = cmd.ExecuteNonQuery();
            //returning no of rows that are affected
            return noOfRows;
        }

        /// <summary>
        /// The below method is to fetch all the records from the products table in database
        /// </summary>
        /// <returns>Dataset that would containn all the records</returns>
        public DataSet ViewProducts()
        {
            // Calling the connection method
            Connection();
            // Assigning the command name for the SQL Command as the stored procedure name which is to be executed
            cmd.CommandText = "usp_VIEW_tbl_Products_PG_ADODotNetDemoCode";
            // Givinng the command type as stored procedure else the above text would be considered as a query
            cmd.CommandType = CommandType.StoredProcedure;
            // Opening the connection
            con.Open();
            // Take a dataset object
            DataSet ds = new DataSet();
            // Take a data adapter that would work as a bridge between database and code. Give the command as an argument.
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // Fill the dataset using the data adapter
            da.Fill(ds);
            // Closing the connection.
            con.Close();
            // Returning the data set that contains all the values
            return ds;

        }

        /// <summary>
        /// The below method would fetch a particular product based on ID from the prodicts table in database
        /// </summary>
        /// <param name="productId">Contains the product id over which the record would be fetched</param>
        /// <returns>Dataset that contains the particular product details</returns>
        public DataSet ViewProductByID(int productId)
        {
            // Calling the connection method
            Connection();
            // Assigning the command name for the SQL Command as the stored procedure name which is to be executed
            cmd.CommandText = "usp_ViewById_tbl_Products_PG_ADODotNetDemoCode";
            // Givinng the command type as stored procedure else the above text would be considered as a query
            cmd.CommandType = CommandType.StoredProcedure;
            // Adding parameters which are expected by the stored procedure
            cmd.Parameters.AddWithValue("@ProID", productId);
            // Opening the connection
            con.Open();
            // Take a dataset object
            DataSet ds = new DataSet();
            // Take a data adapter that would work as a bridge between database and code. Give the command as an argument.
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // Fill the dataset using the data adapter
            da.Fill(ds);
            // Closing the connection.
            con.Close();
            // Returning the data set that contains all the values
            return ds;

        }
    }
}