using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JacobRiosMyRecipes
{
    /// <summary>
    /// Summary description for ImageHandler
    /// </summary>
    public class ImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            SqlDataReader reader = null;
            SqlConnection conn = null;
            SqlCommand command = null;

            try
            {
                conn = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                    ConnectionString);
                command = new SqlCommand("SELECT RecipeImg FROM RecipeTable WHERE Id=" + 
                    context.Request.QueryString["imgID"], conn);
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    context.Response.ContentType = "image/jpg";
                    context.Response.BinaryWrite((byte[])reader["RecipeImg"]);
                }

                reader.Close();
            }

            finally
            {
                conn.Close();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}