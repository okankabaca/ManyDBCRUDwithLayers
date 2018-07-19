using ManyDBCRUDwithLayers.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManyDBCRUDwithLayers.Layers
{
    public class LayerSqlServer : LayerBaseDB
    {
        public string sqlConnectionString = "SERVER=GEBZEHAVUZ17;" +
                "Database =dbStaj;" +
                "uId =LOGOMERKEZ\\Okan.Kabaca;" +
                "Password =Logo1234;" +
                "Integrated Security = true";

        public override DataTable FindAll()
        {
            DataTable dateTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.CommandText = "Select *From tablestaj";
                command.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dateTable);
            }

            return dateTable;

        }

}


}
