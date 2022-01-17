using hello.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace hello.DAL
{
    public class DAL_FORM : Conection
    {
        string str = "";
        public string ManageUser(BAL_FORM objBal)
        {
            try
            {
                connect();
                cmd.Connection = con;
                cmd.CommandText = "dbo.SP_WEB_USER_FORM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ACTION", "INSERT");
                cmd.Parameters.AddWithValue("USERNAME", objBal.UserName);
                cmd.Parameters.AddWithValue("EMAIL", objBal.Email);
                cmd.Parameters.AddWithValue("PASSWORD", objBal.Password);

                cmd.Parameters.Add("MSG", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["MSG"].Value.ToString();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            finally
            {
                disconnect();
            }
            return str;
        }
        public DataTable GetALl(BAL_FORM objBal)
        {
            try
            {
                connect();
                cmd.Connection = con;
                cmd.CommandText = "dbo.SP_WEB_USER_FORM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ACTION", "SELALL");
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            finally
            {
                disconnect();
            }
            return dt;
        }

        public DataTable GETDETAIL(BAL_FORM objBal)
        {
            try
            {
                connect();
                cmd.Connection = con;
                cmd.CommandText = "dbo.SP_WEB_USER_FORM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ACTION", "SEL");
                cmd.Parameters.AddWithValue("USERID", objBal.USERID);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                disconnect();
            }
            return dt;
        }

        public string Delete(BAL_FORM objBal)
        {
            str = "";
            try
            {
                connect();
                cmd.Connection = con;
                cmd.CommandText = "dbo.SP_WEB_USER_FORM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ACTION", "DELETE");
                cmd.Parameters.AddWithValue("USERID", objBal.USERID);
                
                cmd.Parameters.Add("MSG", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["MSG"].Value.ToString();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            finally
            {
                disconnect();
            }
            return str;
        }


        public string UPDATE(BAL_FORM objBal)
        {
            try
            {
                connect();
                cmd.Connection = con;
                cmd.CommandText = "dbo.SP_WEB_USER_FORM";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ACTION", "UPDATE");
                cmd.Parameters.AddWithValue("USERID", objBal.USERID);
                cmd.Parameters.AddWithValue("USERNAME", objBal.UserName);
                cmd.Parameters.AddWithValue("EMAIL", objBal.Email);
                cmd.Parameters.AddWithValue("PASSWORD", objBal.Password);

                cmd.Parameters.Add("MSG", SqlDbType.VarChar, 1000).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                str = cmd.Parameters["MSG"].Value.ToString();
            }
            catch (Exception ex)
            {
                str = ex.Message;
            }
            finally
            {
                disconnect();
            }
            return str;
        }
    }
}
