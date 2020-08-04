using InventorySystem.DataManager;
using InventorySystem.Models;
using InventorySystem.Models.AdminModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace InventorySystem.DAL
{
    public class HomeDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        public ResultResponse UserRegistration(UserRegistrationModel userRegistration)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.ERPSYSTEM);
                ResultResponse result = new ResultResponse();
                var userInfo = new JavaScriptSerializer().Serialize(userRegistration.UserInformation);
                var companyInfo = new JavaScriptSerializer().Serialize(userRegistration.CompanyModel);
                var moduleList = new JavaScriptSerializer().Serialize(userRegistration.UserModuleList);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@UserInformation", userInfo));
                aParameters.Add(new SqlParameter("@CompanyInformation", companyInfo));
                aParameters.Add(new SqlParameter("@CheckedModuleList", moduleList));
                aParameters.Add(new SqlParameter("@RegisterEmail", userRegistration.UserInformation.UserEmail));
                result.PrimaryKey = accessManager.SaveDataReturnPrimaryKey("sp_UserRegistration", aParameters);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
        public ResultResponse CheckLoginFrom(string userEMail,string userPassword)
        {
            ResultResponse user = new ResultResponse();
            try
            {
                accessManager.SqlConnectionOpen(DataBase.ERPSYSTEM);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@UserEmail", userEMail));
                aParameters.Add(new SqlParameter("@UserPassword", userPassword));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_CheckUserLogin", aParameters);
                while (dr.Read())
                {
                    user.IsSuccess = true;
                    user.PrimaryKey =(int) dr["UserId"];
                    user.Msg = dr["UserName"].ToString();
                }
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
    }
}