using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ManyDBCRUDwithLayers.Layers
{
    public class LayerPostgreSql : LayerBaseDB
    {
        public string postgreSqlConnection = "Server=127.0.0.1;" +
            "Port=5432;Database=dbSource;" +
            "User Id = postgres;" +
            "Password = Logo1234;" +
            "Integrated Security = true;";


        public override DataTable FindAll()
        {
            DataTable dataTable = new DataTable();

            using (NpgsqlConnection connection = new NpgsqlConnection(postgreSqlConnection))
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                connection.Open();
                command.CommandText = "Select *From tablestaj";
                command.Connection = connection;

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);

                dataAdapter.Fill(dataTable);
            }

            return dataTable;
        }
    }
}