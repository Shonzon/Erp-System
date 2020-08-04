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
    public class UserInfoDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();
        public ResultResponse AddNewUser(UserInformation userInformation,int userId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.ERPSYSTEM);
                ResultResponse result = new ResultResponse();
                var userInfo = new JavaScriptSerializer().Serialize(userInformation);
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@userInformation", userInfo));
                aParameters.Add(new SqlParameter("@userId", userId));
                result.PrimaryKey = accessManager.SaveDataReturnPrimaryKey("sp_AddNewUserByAdmin", aParameters);
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
    }
}