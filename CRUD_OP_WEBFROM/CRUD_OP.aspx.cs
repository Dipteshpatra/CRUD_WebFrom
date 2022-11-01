using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CRUD_OP_WEBFROM
{
    public partial class CRUD_OP : System.Web.UI.Page
    { 

         SqlConnection sqlConnection = new SqlConnection(@"Data Source =.; Initial Catalog = StudentManagment; Integrated Security = True");
    protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void add_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("InsertStudent", sqlConnection);
            //craete crud
              cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StdName", SqlDbType.VarChar, 50).Value = StdName.Text.ToString();
            cmd.Parameters.Add("@StdCls", SqlDbType.VarChar, 50).Value = StdCls.Text.ToString();
            cmd.Parameters.Add("@StdMno", SqlDbType.BigInt).Value =Int64.Parse(StdMno.Text);
            cmd.Parameters.Add("@StdStrm", SqlDbType.VarChar, 50).Value = StdStrm.Text.ToString();
            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                message.Text = "Data Updated";
            }

            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                sqlConnection.Close(); 
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                string updatequery = "EXEC SP_UpdateStudentInfo  '" + StdName.Text + "' , '" + StdCls.Text + "','" + StdMno.Text + "','" + StdStrm.Text + "' ";
                SqlCommand Command = new SqlCommand(updatequery, sqlConnection);
                Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        protected void Read_Click(object sender, EventArgs e)
        {
            try
            {
                sqlConnection.Open();
                string displayquery = "select*from SP_DisPlayStudentInfo";
                SqlCommand Command = new SqlCommand(displayquery, sqlConnection);
                Command.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(Command);
                da.Fill(dt);
                Display.DataSource = dt;
                Display.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            { sqlConnection.Close(); }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

            try
            {
                sqlConnection.Open();
                string deletequery = "Exec SP_DeleteStudentinfo '" + StdName.Text + "' ";
                SqlCommand cmd = new SqlCommand(deletequery, sqlConnection);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
}