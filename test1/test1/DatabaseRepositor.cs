using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DatabaseRepository
    {

        private const string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\USER\DESKTOP\TEST1\TEST1\TEST1\APPDATA\RESERVOIR.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public void CreateStation(test1.Station station)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();


            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"
INSERT        INTO    Station(ReservoirName, ReservoirIdentifier, EffectiveCapacity, DeadStorageLevel,FullWaterLevel,CatchmentAreaRainfall, InflowVolume, OutflowTotal)
VALUES          (N'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')
", station.ReservoirName, station.ReservoirIdentifier, station.EffectiveCapacity, station.DeadStorageLevel, station.FullWaterLevel, station.CatchmentAreaRainfall, station.InflowVolume, station.OutflowTotal);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}



