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
    public partial class Invoice : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        DataTable dt = new DataTable();
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
           // Label1.Text = Request["Id1"];
            SqlCommand cmd = new SqlCommand("Select * from booking where username='"+ Session["username"]+ "'and Id1=(select max(Id1)from booking) ", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label7.Text = dr["Id1"].ToString();
                Label8.Text = dr["first_name"].ToString() + dr["last_name"].ToString();
            }
            con.Close();
            con.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from booking where username='"+Session["username"]+"' and Id1=(select max(Id1)from booking)", con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
            if(dr1.HasRows==true)
            {
                GridView1.DataSource = dr1;
                GridView1.DataBind();
            }
            con.Close();
            //grid();
        }
        /*public void grid()
        {
            dt.Columns.Add("Id");
            dt.Columns.Add("name");
            dt.Columns.Add("price");
            dt.Columns.Add("image");
            dt.Columns.Add("category");
            dt.Columns.Add("quantity");
            dt.Columns.Add("total");
            con.Open();
            string query ="Select * from booking where Id1="+ Label1.Text;
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = query;
            cmd1.Connection = con;
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd1;
            DataSet ds = new DataSet();
            da.Fill(ds);
            int totalrows = ds.Tables[0].Rows.Count;
            int i = 0;
            int grandtotal = 0;
            while (i < totalrows)
            {
                DataRow dr1;
                dr1 = dt.NewRow();
                dr1["Id1"] = ds.Tables[0].Rows[i]["Id1"].ToString();
                dr1["name"] = ds.Tables[0].Rows[0]["name"].ToString();
                dr1["price"] = ds.Tables[0].Rows[0]["price"].ToString();
                dr1["image"] = ds.Tables[0].Rows[0]["image"].ToString();
                dr1["category"] = ds.Tables[0].Rows[0]["category"].ToString();
                dr1["quantity"] = Request.QueryString["quantity"];
                int p = Convert.ToInt32(ds.Tables[0].Rows[0]["price"].ToString());
                int q = Convert.ToInt32(Request.QueryString["quantity"]);
                int total = p * q;
                dr1["total"] = total;
                grandtotal = grandtotal + total;
                dt.Rows.Add(dr);
                i = i + 1;
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();


            con.Close();
        }
        public int grandtotal()
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int gtotal = 0;
            while (i < nrow)
            {
                gtotal = gtotal + Convert.ToInt32(dt.Rows[i]["total"].ToString());
                i = i + 1;
            }
            return gtotal;
        }*/
    }
}