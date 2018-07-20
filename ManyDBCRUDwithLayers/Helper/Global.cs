using ManyDBCRUDwithLayers.Layers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyDBCRUDwithLayers.App_Start
{
    public static class Global
    {
        public static LayerBaseDB myDB;

        static Global()
        {
           
        }

        public static void setDB (bool controlDB)
        {
            if (controlDB)
                myDB = new LayerSqlServer();
            else
                myDB = new LayerPostgreSql();
        }


    }
}