using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace JacobRiosMyRecipes.Presentation
{
    /// <summary>
    /// Summary description for FavImageHandler
    /// </summary>
    public class FavImageHandler : IHttpHandler, System.Web.SessionState.IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            SqlDataReader reader = null;
            SqlConnection conn = null;
            SqlCommand command = null;
            string userName = context.Session["userName"].ToString();

            if(userName == null)
            {
                userName = "Guest";
            }

            try
            {
                conn = new SqlConnection(
                    ConfigurationManager.ConnectionStrings["RecipeDatabaseConnectionString1"].
                    ConnectionString);
                command = new SqlCommand("SELECT RecipeImg FROM FavoriteTable" + userName +
                    " WHERE Id=" + context.Request.QueryString["imgID"], conn);
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