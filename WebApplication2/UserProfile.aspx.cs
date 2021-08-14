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
    public partial class UserProfile : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            if (Session["username"] != null)
            {
                Label1.Text = "Welcome "+Session["username"].ToString();
                SqlCommand cmd = new SqlCommand("Select * from [user] where username='" + Session["username"] + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    TextBox1.Text = dr["first_name"].ToString();
                    TextBox2.Text = dr["last_name"].ToString();
                    TextBox3.Text = dr["email_id"].ToString();
                    TextBox4.Text = dr["contact_no"].ToString();
                    TextBox5.Text = dr["username"].ToString();
                    //string path = dr["image"].ToString();
                    //Label4.Text = path;
                    //Image1.ImageUrl = "~/Uploadfood/" +Server.MapPath(path);
                }
                con.Close();
            }

        }
    }
}