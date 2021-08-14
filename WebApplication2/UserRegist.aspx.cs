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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
            //Label7.Text = "Connected..!!";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            //cmd.Connection = con;
            string querry = "insert into [user] (Id,first_name,last_name,email_id,contact_no,username,password) values (@Id,@first_name,@last_name,@email_id,@contact_no,@username,@password)";
            SqlCommand cmd = new SqlCommand(querry, con);

            SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(Id as int)),0)+1 From [user]", con);
            sda.Fill(dt);
            Label7.Text = dt.Rows[0][0].ToString();
            cmd.Parameters.AddWithValue("Id", Label7.Text);
            cmd.Parameters.AddWithValue("first_name", TextBox1.Text);
            cmd.Parameters.AddWithValue("last_name", TextBox2.Text);
            cmd.Parameters.AddWithValue("email_id", TextBox3.Text);
            cmd.Parameters.AddWithValue("contact_no", TextBox4.Text);
            cmd.Parameters.AddWithValue("username", TextBox5.Text);
            cmd.Parameters.AddWithValue("password", TextBox7.Text);
       
            cmd.ExecuteNonQuery();
            Response.Redirect("Userlogin.aspx");
        }
    }
}