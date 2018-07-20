using ManyDBCRUDwithLayers.Models;
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


        public override TableStajModel FindOne(int id)
        {
            TableStajModel tableStajModel = new TableStajModel();
            DataTable dataTable = new DataTable();

            using (NpgsqlConnection connection = new NpgsqlConnection(postgreSqlConnection))
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                connection.Open();
                command.CommandText = "Select *From tablestaj " +
                    "Where id=@id";
                command.Parameters.AddWithValue("@id",id);

                command.Connection = connection;

                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);

                dataAdapter.Fill(dataTable);
            }

            if (dataTable.Rows.Count >= 1)
            {
                tableStajModel.Id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                tableStajModel.name = dataTable.Rows[0][1].ToString();
                tableStajModel.lastname = dataTable.Rows[0][2].ToString();
                tableStajModel.age = Convert.ToInt32(dataTable.Rows[0][3].ToString());
                tableStajModel.user = Convert.ToInt32(dataTable.Rows[0][4].ToString());
            }

            return tableStajModel;
        }



        public override int Create(TableStajModel tableStaj)
        {
            int result;

            using (NpgsqlConnection connection = new NpgsqlConnection(postgreSqlConnection))
            using (NpgsqlCommand command = new NpgsqlCommand())
            {
                connection.Open();

                command.CommandText = "Insert Into tablestaj " +
                    "(name,lastname,age,\"user\")" +
                    " Values(@name,@lastname,@age,@user)";
                command.Parameters.AddWithValue("@name", tableStaj.name);
                command.Parameters.AddWithValue("@lastname", tableStaj.lastname);
                command.Parameters.AddWithValue("@age", tableStaj.age);
                command.Parameters.AddWithValue("@user", tableStaj.user);

                command.Connection = connection;
                result = command.ExecuteNonQuery();
            }
            return result;
        }
    }
}