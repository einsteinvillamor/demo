using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace general_EDV
{
    public class general
    {

        public static SqlConnection getCon()
        {
            string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                return con;
            }
            catch (Exception ex)
            {

                throw; 
            }
        }

        public static SqlConnection getCon(string con)
        {
            string conString = ConfigurationManager.ConnectionStrings[con].ToString();

            SqlConnection con = new SqlConnection(conString);

            try
            {
                con.Open();
                return con;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static Boolean performAction(string sql)
        {
            using (SqlConnection con = getCon())
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                int numberofRowAffected = cmd.ExecuteNonQuery();

                if (numberofRowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static Boolean performAction(SqlCommand cmd)
        {
            using (SqlConnection con = getCon())
            {
                cmd.Connection = con;

                int numberofRowAffected = cmd.ExecuteNonQuery();

                if (numberofRowAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static string getSingle(string sql)
        {
            using (SqlConnection con = getCon())
            {
                SqlCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                try
                {
                    object retrunedValue = cmd.ExecuteScalar();
                    if (retrunedValue != null)
                    {
                        return retrunedValue.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    throw; 
                }

            }
        }

        public static string getSingle(SqlCommand cmd)
        {
            using (SqlConnection con = getCon())
            {

                cmd.Connection = con;

                try
                {
                    object retrunedValue = cmd.ExecuteScalar();
                    if (retrunedValue != null)
                    {
                        return retrunedValue.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                catch (Exception ex)
                {
                    throw; 
                }

            }
        }

        public static DataSet getset(string sql)
        {
            using (SqlConnection con = getCon())
            {
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand(sql);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection = con;

                da.Fill(ds,"GetTable");
                return ds;

            }
        }

        public static DataSet getset(SqlCommand cmd)
        {
            using (SqlConnection con = getCon())
            {
                DataSet ds = new DataSet();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Connection = con;

                da.Fill(ds, "GetTable");
                return ds;

            }
        }

    }
}