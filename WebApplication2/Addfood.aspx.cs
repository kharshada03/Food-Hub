using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Addfood : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            string query = "Insert into [food] (Id,name,price,image,category) values(@Id,@name,@price,@image,@category)";
            SqlCommand cmd = new SqlCommand(query, con);
            string str = FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploadfood/" + str));
            string file = "~/Uploadfood/" + str.ToString();
            SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(Id as int)),0)+1 From [food]", con);
            sda.Fill(dt);
            Label5.Text = dt.Rows[0][0].ToString();
            cmd.Parameters.AddWithValue("Id", Label5.Text);
            cmd.Parameters.AddWithValue("name", TextBox1.Text);
            cmd.Parameters.AddWithValue("price", TextBox2.Text);
            cmd.Parameters.AddWithValue("image", file);
            cmd.Parameters.AddWithValue("category",DropDownList1.SelectedValue);

            cmd.ExecuteNonQuery();
            //Label6.Text = "added in data";
            Response.Redirect("Viewfood.aspx");
        }
    }
}