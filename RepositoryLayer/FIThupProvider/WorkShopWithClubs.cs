﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIThupProvider
{
    public class WorkShopWithClubs : Core.Disposable
    {
        public List<Entities.WorkShopWithClubs> getWorkShopWithClubs(int ClubHistoryID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubsUpdateId", Value =  ClubHistoryID },

            };
            return DAL2.ExecuteReader<Entities.WorkShopWithClubs>("spGetWorkShopWithClubs");
        }
        public List<Entities.WorkShopWithClubs> getWorkShopDetailsByID(int WorkShopID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@WorkShopID", Value =  WorkShopID },

            };
            return DAL2.ExecuteReader<Entities.WorkShopWithClubs>("spGetWorkShopDetailsByID");
        }

        public List<Entities.WorkShopWithClubs> getWorkshopsByClubID(int ClubID)
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@ClubID", Value =  ClubID },
            };
            return DAL2.ExecuteReader<Entities.WorkShopWithClubs>("spGetWorkshopsByClubID");
        }
        public List<Entities.WorkShopWithClubs> getUpCommingWorkshops()
        {

            using var DAL2 = new DataAccess.DataAccessLayer();
           
            return DAL2.ExecuteReader<Entities.WorkShopWithClubs>("spGetUpCommingWorkshops");
        }
        public List<Entities.WorkShopWithClubs> SearchWorkShopWithClubsOnString(string str)
        {
            if (str != null)
            {
                str = "%" + str + "%";
            }
            else
            {
                str = "";
            }
            using var DAL2 = new DataAccess.DataAccessLayer();
            DAL2.Parameters = new List<SqlParameter> {
                new SqlParameter{ ParameterName = "@string", Value =  str },

            };
            return DAL2.ExecuteReader<Entities.WorkShopWithClubs>("spSearchWorkShopWithClubsOnString");
        }
    }
}
