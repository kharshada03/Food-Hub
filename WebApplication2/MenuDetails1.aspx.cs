using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class MenuDetails1 : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            /*Label1.Text = Request["Id"];
            SqlCommand cmd = new SqlCommand("Select * from food where Id='" + Label1.Text + "'", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();*/
            con.Close();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            
                DropDownList txt = (DropDownList)(e.Item.FindControl("DropDownList1"));
           // string txt1 = Convert.ToString(txt);
                Response.Redirect("Cart.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + txt.SelectedItem.ToString());
            
        }
    }
}