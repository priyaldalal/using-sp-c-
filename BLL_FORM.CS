using hello.BAL;
using hello.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace hello.BLL
{
    public class BLL_FORM
    {

        public string ManageUser(BAL_FORM objBal)
        {
            DAL_FORM objDal = new DAL_FORM();
            return objDal.ManageUser(objBal);
        }
        public DataTable GetALl(BAL_FORM objBal)
        {
            DAL_FORM objDal = new DAL_FORM();
            return objDal.GetALl(objBal);
        }
        public DataTable GETDETAIL(BAL_FORM objBal)
        {
            DAL_FORM objDal = new DAL_FORM();
            return objDal.GETDETAIL(objBal);
        }

        public string Delete(BAL_FORM objBal)
        {
            DAL_FORM objDal = new DAL_FORM();
            return objDal.Delete(objBal);
        }
        public string UPDATE(BAL_FORM objBal)
        {
            DAL_FORM objDal = new DAL_FORM();
            return objDal.UPDATE(objBal);
        }
        public DataTable GetData(BAL_FORM objBal)
        {
            DAL_FORM objDal = new DAL_FORM();
            return objDal.GetData(objBal);
        }
        
    }
}
