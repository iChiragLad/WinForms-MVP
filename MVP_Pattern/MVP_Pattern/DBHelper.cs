using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace MVP_Pattern
{
    class DBHelper : IDisposable
    {
        SqlConnection connection;
        SqlCommand command;

        public void OpenConnection()
        {
            string conStr = ConfigurationManager.ConnectionStrings["SqlServerConnect"].ConnectionString;
            connection = new SqlConnection(conStr);
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }

        public void Insert(CarModel car)
        {
            string cmd = "INSERT INTO CarDB (OwnerID, Model, Make, YOP, Color) VALUES(@OwnerID, @Model, @Make, @YOP, @Color)";

            command = new SqlCommand(cmd, connection);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@OwnerID";
            parameter.Value = car.OwnerID;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Model";
            parameter.Value = car.Model;
            parameter.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Make";
            parameter.Value = car.Make;
            parameter.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@YOP";
            parameter.Value = car.YOP;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            parameter = new SqlParameter();
            parameter.ParameterName = "@Color";
            parameter.Value = (car.ColorCode.Name);
            parameter.SqlDbType = System.Data.SqlDbType.VarChar;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();
        }

        public void Modify(CarModel car)
        {
            string cmd = "DELETE FROM CarDB WHERE OwnerID = @OwnerID";

            command = new SqlCommand(cmd, connection);

            SqlParameter parameter = new SqlParameter();
            parameter.ParameterName = "@OwnerID";
            parameter.Value = car.OwnerID;
            parameter.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(parameter);

            command.ExecuteNonQuery();

            this.Insert(car);

        }

        public CarModel Search(Int32 id)
        {
            CarModel dummy = new CarModel();
            string cmd = "SELECT * from CarDB where OwnerID = '" + id + "'";

            command = new SqlCommand(cmd, connection);

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                dummy.OwnerID = Convert.ToInt32(reader["OwnerID"].ToString());
                dummy.Model = reader["Model"].ToString();
                dummy.Make = reader["Make"].ToString();
                dummy.YOP = Convert.ToInt32(reader["YOP"]);
                dummy.ColorCode = System.Drawing.Color.FromName(Convert.ToString(reader["Color"]));
            }

            return dummy;
        }

        public void Dispose()
        {
            connection.Dispose();
            command.Dispose();
        }
    }
}
