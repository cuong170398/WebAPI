using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testAPI.Models;

namespace testAPI.Controllers
{
    public class CatalogController : ApiController
    {
        public SqlConnection con;
        public void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["myConnectionString"].ToString();
            con = new SqlConnection(constring);
        }
        //string cs = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;

        DataAccess da = new DataAccess();
        public IEnumerable<CatalogModel> GetCatalog()
        {
            List<CatalogModel> CatalogList = new List<CatalogModel>();
            DataTable dt = da.GetTable("EXEC dbo.select_Catalog");
            da.com.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var Catalog = new CatalogModel();
                Catalog.Catalogs_id = Convert.ToInt32(dt.Rows[i]["Catalogs_id"].ToString());
                Catalog.Catalogs_name = dt.Rows[i]["Catalogs_name"].ToString();
                Catalog.Catalogs_image = dt.Rows[i]["Catalogs_image"].ToString();
                Catalog.Catalogs_Status = Convert.ToBoolean(dt.Rows[i]["Catalogs_Status"].ToString());
                CatalogList.Add(Catalog);
            }
            return CatalogList;
        }
        public IEnumerable<CatalogModel> Get(int id)
        {
            List<CatalogModel> CatalogList = new List<CatalogModel>();
            DataTable dt = da.GetTable("EXEC Select_CatalogId @Catalogs_id=" + id);
            da.com.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var Catalog = new CatalogModel();
                Catalog.Catalogs_id = Convert.ToInt32(dt.Rows[i]["Catalogs_id"].ToString());
                Catalog.Catalogs_name = dt.Rows[i]["Catalogs_name"].ToString();
                Catalog.Catalogs_image = dt.Rows[i]["Catalogs_image"].ToString();
                Catalog.Catalogs_Status = Convert.ToBoolean(dt.Rows[i]["Catalogs_Status"].ToString());
                CatalogList.Add(Catalog);
            }
            return CatalogList;
        }
        // POST api/values
        public bool Post([FromBody]CatalogModel emp)
        {
                connection();
                SqlCommand com = new SqlCommand("dbo.Insert_Catalogs", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Catalogs_name", emp.Catalogs_name);
                com.Parameters.AddWithValue("@Catalogs_image", emp.Catalogs_image);
                com.Parameters.AddWithValue("@Catalogs_Status", emp.Catalogs_Status);
                con.Open();
                int i = com.ExecuteNonQuery();
                con.Close();

                if (i >= 1)
                    return true;
                else
                    return false;
        }

        // PUT api/values/5
        public bool Put(CatalogModel emp)
        {
            connection();
            SqlCommand com = new SqlCommand("dbo.Update_Catalos", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Catalogs_id", emp.Catalogs_id);
            com.Parameters.AddWithValue("@Catalogs_name", emp.Catalogs_name);
            com.Parameters.AddWithValue("@Catalogs_image", emp.Catalogs_image);
            com.Parameters.AddWithValue("@Catalogs_Status", emp.Catalogs_Status);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // DELETE api/values/5
        public bool  Delete(int id)
        {
            //return "tại sao không được";
            connection();
            SqlCommand com = new SqlCommand("dbo.Delete_Api", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Catalogs_id", id);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}
