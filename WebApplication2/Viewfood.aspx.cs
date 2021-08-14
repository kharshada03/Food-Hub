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
    public partial class Viewfood : System.Web.UI.Page
    {
        string connectionString;
        SqlConnection con;
        //SqlCommand cmd;
        //DataTable dt = new DataTable();
        //SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
            connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodhub;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from food where category='Veg'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            DataList1.DataSource=dt;
            DataList1.DataBind();

            SqlCommand cmd1 = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from food where category='Non-Veg'";
            cmd.ExecuteNonQuery();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda.Fill(dt1);
            DataList2.DataSource = dt1;
            DataList2.DataBind();
            con.Close();
        }

       /* protected void DataList1_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            if(e.CommandName=="Del")
            {
                for (int i = 0; i < DataList1.Items.Count; i++)
                {
                    LinkButton chk = (LinkButton)DataList1.Items[i].FindControl("LinkButton1");
                    if (chk.CommandName == "Del")
                    {
                        string id = (string)DataList1.DataKeys[e.Item.ItemIndex];
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Delete from food where Id=@id";
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                        //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    }
                }
                DataList1.DataBind();
                con.Close();
            }
        }*/

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            con.Open();
            //Label1.Text = Request["Id"];
            string id = ((LinkButton)sender).CommandArgument;
            SqlCommand cmd= con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from food where Id='"+id+"'";
            cmd.ExecuteNonQuery();
           /* DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            DataList1.DataSource = dt;*/
            DataList1.DataBind();
            con.Close();
            Response.Redirect("Viewfood.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            con.Open();
            //Label1.Text = Request["Id"];
            string id = ((LinkButton)sender).CommandArgument;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Delete from food where Id='" + id + "'";
            cmd.ExecuteNonQuery();
            /* DataTable dt = new DataTable();
             SqlDataAdapter sda = new SqlDataAdapter(cmd);
             sda.Fill(dt);
             DataList1.DataSource = dt;*/
            DataList2.DataBind();
            con.Close();
            Response.Redirect("Viewfood.aspx");
        }
    }
}