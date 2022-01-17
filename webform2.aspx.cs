using hello.BAL;
using hello.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hello
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [System.Web.Services.WebMethod]
        public static string Save(string USERNAME, string EMAIL, string PASSWORD)
        {
            string str = "";
            BAL_FORM objBal = new BAL_FORM();
            BLL_FORM objBll = new BLL_FORM();

            objBal.UserName = USERNAME;
            objBal.Email = EMAIL;
            objBal.Password = PASSWORD;
            str = objBll.ManageUser(objBal);

            return str;
        }
        [System.Web.Services.WebMethod]
        public static string GetAll()
        {
            string str = "";
            BAL_FORM objBal = new BAL_FORM();
            BLL_FORM objBll = new BLL_FORM();

            DataTable dt = objBll.GetALl(objBal);

            dt.TableName = "tblData";
            using (StringWriter sw = new StringWriter())
            {
                dt.WriteXml(sw);
                str = sw.ToString();
            }
            return str;
        }
        [System.Web.Services.WebMethod]
        public static string GETDETAIL(int userid)
        {
            string str = "";
            BAL_FORM objBal = new BAL_FORM();
            BLL_FORM objBll = new BLL_FORM();
            objBal.USERID = userid;
            DataTable dt = objBll.GETDETAIL(objBal);

            dt.TableName = "tblData";
            using (StringWriter sw = new StringWriter())
            {
                dt.WriteXml(sw);
                str = sw.ToString();
            }
            return str;
        }

        //[WebMethod]
        //public static string DelData(int USERID, string USERNAME, string EMAIL, string PASSWORD)
        //{
        //    string str = "";
        //    try
        //    {
                
                
        //        BAL_FORM objBal = new BAL_FORM();
        //        BLL_FORM objBll = new BLL_FORM();
        //        objBal.Action = "DELETE";
        //        objBal.USERID = USERID;
        //        objBal.UserName = USERNAME;
        //        objBal.Email = EMAIL;
        //        objBal.Password = PASSWORD;
        //        dt.TableName = "tblData";
        //        str = objBll.Delete(objBal);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message == "USED")
        //            str = "you can not delete this record.It is being used in entry!";
        //        else
        //            str = ex.Message;
        //    }
        //    return str;
        //}
        [System.Web.Services.WebMethod]
        public static string UPDATE(int USERID,string USERNAME, string EMAIL, string PASSWORD)
        {
            string str = "";
            BAL_FORM objBal = new BAL_FORM();
            BLL_FORM objBll = new BLL_FORM();
            objBal.USERID = USERID;
            objBal.UserName = USERNAME;
            objBal.Email = EMAIL;
            objBal.Password = PASSWORD;
            str = objBll.UPDATE(objBal);

            return str;
        }

        [System.Web.Services.WebMethod]
        public static string DELETE(int USERID)
        {
            string str = "";
            BAL_FORM objBal = new BAL_FORM();
            BLL_FORM objBll = new BLL_FORM();
            objBal.USERID = USERID;
         
            str = objBll.Delete(objBal);

            return str;
        }

    }
}
