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
    public partial class Cart : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        SqlCommand cmd;
        DataTable dt = new DataTable();
        SqlDataReader sdr;
        DataRow dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(Id1 as int)),0)+1 From [booking]", con);
            DataTable dt1 = new DataTable();
            sda.Fill(dt1);
            Label5.Text = dt1.Rows[0][0].ToString();
            if (Session["username"] != null)
            {
                SqlCommand cmd1 = new SqlCommand("Select * from [user] where username='" + Session["username"] + "'", con);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
                {
                    Label2.Text = dr1["first_name"].ToString();
                    Label3.Text = dr1["last_name"].ToString();
                    Label4.Text = dr1["contact_no"].ToString();

                }
            }
            con.Close();

            // dx.Columns.Add("Quantity");
            /*if (Session["Data"] != null)
            {
                DataTable dx = (DataTable)Session["Data"];
                dx.Merge(dt);
                Session["Data"] = dx;
                dr = dt.NewRow();
                //TextBox1.Text = Request["qu"];
                dr["quantity"] = Request.QueryString["quantity"];

                GridView1.DataSource = dx;
                GridView1.DataBind();
                //dx.Rows.Add(Request["qu"].ToString());
            }

            else
            {
                DataTable dt = (DataTable)Session["Data"];

                Session["Data"] = dt;
                //TextBox1.Text = Request["qu"];

                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            if (Session["username"] != null)
            {
                Label1.Text = Session["username"].ToString();
                dt = (DataTable)Session["buyitems"];
                if (dt != null)
                {
                    Label1.Text = dt.Rows.Count.ToString();
                }
                else
                {
                    Label1.Text = "0";
                }
            }*/
            con.Open();
                if (!IsPostBack)
            {
                dt.Columns.Add("Id");
                dt.Columns.Add("name");
                dt.Columns.Add("price");
                dt.Columns.Add("image");
                dt.Columns.Add("category");
                dt.Columns.Add("quantity");
                dt.Columns.Add("total");
            }
            if(Request.QueryString["Id"] !=null)
            {
                if(Session["buyitems"]==null)
                {
                    dr = dt.NewRow();
                   // string query = "Select * from food where Id=" + Request.QueryString["Id"];
                    SqlCommand cmd = new SqlCommand("Select * from food where Id=" + Request.QueryString["Id"],con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dr["Id"] = ds.Tables[0].Rows[0]["Id"].ToString();
                    dr["name"] = ds.Tables[0].Rows[0]["name"].ToString();
                    dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();
                    dr["image"] = ds.Tables[0].Rows[0]["image"].ToString();
                    dr["category"] = ds.Tables[0].Rows[0]["category"].ToString();
                    dr["quantity"] = Request.QueryString["quantity"];
                    int p = Convert.ToInt32(ds.Tables[0].Rows[0]["price"].ToString());
                    int q = Convert.ToInt32(Request.QueryString["quantity"]);
                    int total = p * q;
                    dr["total"] = total;
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["buyitems"] = dt;
                    GridView1.FooterRow.Cells[4].Text = "Total";
                    GridView1.FooterRow.Cells[5].Text = grandtotal().ToString();
                    Response.Redirect("Cart.aspx");
                }
                else
                {
                    dt = (DataTable)Session["buyitems"];
                    int sr;
                    sr = dt.Rows.Count;
                    dr = dt.NewRow();
                    SqlCommand cmd = new SqlCommand("Select * from food where Id=" + Request.QueryString["Id"], con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dr["Id"] = ds.Tables[0].Rows[0]["Id"].ToString();
                    dr["name"] = ds.Tables[0].Rows[0]["name"].ToString();
                    dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();
                    dr["image"] = ds.Tables[0].Rows[0]["image"].ToString();
                    dr["category"] = ds.Tables[0].Rows[0]["category"].ToString();
                    dr["quantity"] = Request.QueryString["quantity"];
                    int p = Convert.ToInt32(ds.Tables[0].Rows[0]["price"].ToString());
                    int q = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                    int total = p * q;
                    dr["total"] = total;
                    dt.Rows.Add(dr);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    Session["buyitems"] = dt;
                    GridView1.FooterRow.Cells[4].Text = "Total";
                    GridView1.FooterRow.Cells[5].Text = grandtotal().ToString();
                }
            }
            else
            {
                dt = (DataTable)Session["buyitems"];
                GridView1.DataSource = dt;
                GridView1.DataBind();
                if(GridView1.Rows.Count>0)
                {
                    GridView1.FooterRow.Cells[4].Text = "Total";
                    GridView1.FooterRow.Cells[5].Text = grandtotal().ToString();
                }
            }
            Label1.Text = GridView1.Rows.Count.ToString();
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DataTable dt;
            dt = (DataTable)Session["buyitems"];
            
            for (int i=0;i<=dt.Rows.Count-1;i++)
            {
               
                SqlCommand cmd = new SqlCommand("Insert into [booking] (Id1,name,category,price,quantity,total,first_name,last_name,username,contact_no) values ('"+Label5.Text+"','"+dt.Rows[i]["name"]+"','"+dt.Rows[i]["category"]+"','"+dt.Rows[i]["price"]+"','"+dt.Rows[i]["quantity"]+"','"+dt.Rows[i]["total"]+"','"+Label2.Text+"','"+Label3.Text+"','"+Session["username"]+"','"+Label4.Text+"') ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                dt.Rows[i].Delete();
               // dt.Clear();
                con.Close();
            }
            dt.Rows.Clear();
            //GridView1.DataSource=null;
            //GridView1.DataBind();
            Response.Redirect("Invoice.aspx");
        }
    }
}