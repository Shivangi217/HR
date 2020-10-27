using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace HR
{
    public partial class WebForm2 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["shivu"].ToString());
            SqlCommand cmd = new SqlCommand();


            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select emp_id from employee where user_name=@user_name and password=@password";

            cmd.Parameters.AddWithValue("@user_name", user_name.Text.Trim().ToString());
            cmd.Parameters.AddWithValue("@password", password.Text.Trim().ToString());
            IUs



            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Session["user"] = user_name.Text.Trim().ToString();

                Response.Redirect("home.aspx");

                con.Close();
            }
            else
            {
                if (user_name.Text.ToString() == "admin" && password.Text.ToString() == "admin")
                {
                    Session["admin"] = user_name.Text.Trim().ToString();

                    con.Close();

                    Response.Redirect("admin.aspx");
                }
                else
                {

                    ClientScript.RegisterStartupScript(Page.GetType(), "validation", "<script language='javascript'>alert('Invalid Username and Password')</script>");
                    con.Close();
                }

            }
        }
    }
}