using hello.BAL;
using hello.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace hello
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static string UserLogin(string USERNAME, string PASSWORD)
        {
            string str = "";
            try
            {
                BAL_FORM objBal = new BAL_FORM();
                BLL_FORM objBll = new BLL_FORM();
                
                objBal.UserName = USERNAME;
                objBal.Password = PASSWORD;
               
                DataTable dtLogin = objBll.GetData(objBal);
                if (dtLogin.Rows.Count > 0)
                {
                    string pass = dtLogin.Rows[0]["PASSWORD"].ToString();
                    if (pass == PASSWORD)
                    {
                        //if(HttpContext.Current != null)
                       
                        str = "y";
                    }
                    else
                    {
                        str = "P/Incorrect password..!";
                    }
                }
                else
                {
                    str = "U/Invalid username or credentials..!";
                }
            }
            catch (Exception ex)
            {
                str = ex.Message.ToString();
            }
            return str;
        }
        [WebMethod]
        public static string Logout()
        {
            HttpContext.Current.Session["USERID"] = null;
            HttpContext.Current.Session["USERNAME"] = null;
           

            HttpContext.Current.Session.Abandon();
            return "y";
        }


       
    }
}
