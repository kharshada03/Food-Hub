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
    public partial class EditFood : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            Label2.Text = Request["Id"];
            SqlCommand cmd = new SqlCommand("Select * from food where Id='" + Label2.Text + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Image1.ImageUrl = dr["image"].ToString();
                TextBox1.Text = dr["name"].ToString();
                //TextBox2.Text = dr["category"].ToString();
                DropDownList1.Text = dr["category"].ToString();
                TextBox2.Text = dr["price"].ToString();
                //string path = dr["image"].ToString();
                //Label4.Text = path;
                //Image1.ImageUrl = "~/Uploadfood/" +Server.MapPath(path);
            }
            con.Close();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            //con = new SqlConnection(connectionString);
            con.Open();
            Label2.Text = Request["Id"];
            
            //string str = FileUpload1.FileName;
            //FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Uploadfood/" + str));
            //string file = "~/Uploadfood/" + str.ToString();
            
            SqlCommand cmd1 = new SqlCommand("Update food set name='"+TextBox1.Text+"',price='"+Convert.ToInt32(TextBox2.Text)+"' where Id='"+Label2.Text+"'", con);
            //cmd1.Parameters.AddWithValue("name", TextBox1.Text);
            //cmd1.Parameters.AddWithValue("price",Convert.ToInt32(TextBox2.Text));
            //cmd1.Parameters.AddWithValue("image", file);
            //cmd1.Parameters.AddWithValue("category",  DropDownList1.SelectedValue);
            cmd1.ExecuteNonQuery();
            Label4.Text = "Updated in data";
            con.Close();
            //Response.Redirect("Viewfood.aspx");
        }
    }
}