using ManyDBCRUDwithLayers.Layers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ManyDBCRUDwithLayers.App_Start
{
    public static class Global
    {
        public static LayerBaseDB myDB;

        static Global()
        {
            if (ConfigurationManager.AppSettings["DBType"]== "MSSQL")
                myDB = new LayerSqlServer();
            else
                myDB = new LayerPostgreSql();
        }

        public static void setDB(bool controlDB)
        {

        }


    }
}