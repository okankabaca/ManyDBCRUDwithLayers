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
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.CommandText = "Select *From tablestaj";
                command.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }

            return dataTable;
        }


        public override TableStajModel FindOne(int id)
        {
            TableStajModel tableStajModel;
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.CommandText = "Select *From tablestaj " +
                    "Where id=@id";
                command.Parameters.AddWithValue("@id", id);

                command.Connection = connection;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataTable);
            }

            if (dataTable.Rows.Count >= 1)
            {
                tableStajModel = new TableStajModel();

                tableStajModel.Id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
                tableStajModel.name = dataTable.Rows[0][1].ToString();
                tableStajModel.lastname = dataTable.Rows[0][2].ToString();
                tableStajModel.age = Convert.ToInt32(dataTable.Rows[0][3].ToString());
                tableStajModel.user = Convert.ToInt32(dataTable.Rows[0][4].ToString());

                return tableStajModel;
            }
            return null;
        }


        public override int Create(TableStajModel tableStaj)
        {
            int result;

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();

                command.CommandText = "Insert Into tablestaj Values(@name,@lastname,@age,@user)";
                command.Parameters.AddWithValue("@name", tableStaj.name);
                command.Parameters.AddWithValue("@lastname", tableStaj.lastname);
                command.Parameters.AddWithValue("@age", tableStaj.age);
                command.Parameters.AddWithValue("@user", tableStaj.user);

                command.Connection = connection;
                result = command.ExecuteNonQuery();
            }
            return result;
        }


        public override int Edit(int id, TableStajModel tableStajModel)
        {
            int result = -1;

            if (this.FindOne(id) != null)
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.CommandText = "Update tablestaj " +
                        "Set name=@name,lastname=@lastname,age=@age,\"user\"=@user " +
                        "Where id=@id";

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", tableStajModel.name);
                    command.Parameters.AddWithValue("@lastname", tableStajModel.lastname);
                    command.Parameters.AddWithValue("@age", tableStajModel.age);
                    command.Parameters.AddWithValue("@user", tableStajModel.user);

                    command.Connection = connection;

                    result = command.ExecuteNonQuery();

                }
            }

            return result;
        }


        public override int Delete(int id)
        {
            int result = -1;

            if (this.FindOne(id) != null)
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();

                    command.CommandText = "Delete From tablestaj " +
                        "Where id=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection = connection;

                    result = command.ExecuteNonQuery();

                }
            }

            return result;
        }

    }

}
