using InventorySystem.DataManager;
using InventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InventorySystem.DAL
{
    public class CommonDAL
    {
        private DataAccessManager accessManager = new DataAccessManager();

        public List<CountryModel> GetAllCountry(int countryId)
        {
            try
            {
                accessManager.SqlConnectionOpen(DataBase.ERPSYSTEM);
                List<CountryModel> countryList = new List<CountryModel>();
                List<SqlParameter> aParameters = new List<SqlParameter>();
                aParameters.Add(new SqlParameter("@CountryId", countryId));
                SqlDataReader dr = accessManager.GetSqlDataReader("sp_GetAllCountry", aParameters);
                while (dr.Read())
                {
                    CountryModel country = new CountryModel();
                    country.CountryId= (int)dr["CountryId"];
                    country.CountryName= dr["CountryName"].ToString();
                    country.CountryCode= dr["CountryCode"].ToString();
                    country.CountryFlag= dr["CountryFlag"].ToString();
                    countryList.Add(country);
                }
                return countryList;
            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                accessManager.SqlConnectionClose();
            }
        }
    }
}