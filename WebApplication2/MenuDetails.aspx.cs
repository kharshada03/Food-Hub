using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
               
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            if (Session["username"] != null)
            {
                Label8.Text = Session["username"].ToString();
                SqlCommand cmd1 = new SqlCommand("Select * from [user] where username='" + Session["username"] + "'", con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    Label10.Text = dr1["first_name"].ToString();
                    Label11.Text = dr1["last_name"].ToString();
                    Label12.Text = dr1["contact_no"].ToString();
                    
                }
            }
            con.Close();
            con.Open();
            //int id =Convert.ToInt32(Request["Id"]);
            Label2.Text = Request["Id"];
            SqlCommand cmd = new SqlCommand("Select * from food where Id='"+Label2.Text+"'",con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               TextBox1.Text = dr["name"].ToString();
               TextBox2.Text = dr["category"].ToString();
                TextBox5.Text = dr["price"].ToString();
               //string path = dr["image"].ToString();
               //Label4.Text = path;
               //Image1.ImageUrl = "~/Uploadfood/" +Server.MapPath(path);
            }
            con.Close();
            con.Open();
            cmd.CommandText = "Select * from food where Id='" + Label2.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            con.Close();
           
                //int a = TextBox5.Text;

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            string b = TextBox3.Text;
            int total = Convert.ToInt32(TextBox5.Text) * Convert.ToInt32(b);
            TextBox4.Text = Convert.ToString(total);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            //cmd.Connection = con;
            
                string querry = "insert into [booking] (Id1,name,category,price,quantity,total,first_name,last_name,username,contact_no) values (@Id1,@name,@category,@price,@quantity,@total,@first_name,@last_name,@username,@contact_no)";
                SqlCommand cmd = new SqlCommand(querry, con);

                SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(Id1 as int)),0)+1 From [booking]", con);
                sda.Fill(dt);
                Label7.Text = dt.Rows[0][0].ToString();
                cmd.Parameters.AddWithValue("Id1", Label7.Text);
                cmd.Parameters.AddWithValue("name", TextBox1.Text);
                cmd.Parameters.AddWithValue("category", TextBox2.Text);
                cmd.Parameters.AddWithValue("price", TextBox5.Text);
                cmd.Parameters.AddWithValue("quantity", TextBox3.Text);
                cmd.Parameters.AddWithValue("total", TextBox4.Text);
                cmd.Parameters.AddWithValue("first_name", Label10.Text);
                cmd.Parameters.AddWithValue("last_name", Label11.Text);
                cmd.Parameters.AddWithValue("username", Label8.Text);
                cmd.Parameters.AddWithValue("contact_no", Label12.Text);
                cmd.ExecuteNonQuery();
                Response.Redirect("Invoice.aspx");
            
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            /* DataTable dt = new DataTable();
             dt = (DataTable)Session["buyitems"];
             if(dt!=null)
             {
                 Label2.Text = dt.Rows.Count.ToString();
             }
             Response.Redirect("Cart.aspx?Id=" + Label2.Text+ "&quantity=" + Convert.ToString(TextBox3.Text));*/
            int id = Convert.ToInt32(Request.QueryString["Id"]);
            string quantity = Convert.ToString(TextBox3.Text);
            string q = Convert.ToString(Request.QueryString["quantity"]);
            DataTable dt = GetData(id,q);

            if (Session["Data"] != null)
            {
                DataTable dx = (DataTable)Session["Data"];
                dx.Merge(dt);
                Session["Data"] = dx;
                Response.Redirect("Cart.aspx?quantity="+q);
                //gvCartItems.DataSource = dx;
                //gvCartItems.DataBind();
            }
            else
            {
                Session["Data"] = dt;
                Response.Redirect("Cart.aspx?quantity=" + q);
                //gvCartItems.DataSource = dt;
                //gvCartItems.DataBind();
            }
        }
        private DataTable GetData(int id,string q)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            string query = "SELECT * FROM food WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query);
            q = Convert.ToString(Request.QueryString["quantity"]);
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Id", id);
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        //q = Convert.ToString(TextBox3.Text);
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}