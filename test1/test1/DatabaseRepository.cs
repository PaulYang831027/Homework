using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class DatabaseRep
    {

        private const string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Reservoir;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


//        public void CreateStation(Models.Station station)
//        {
//            var connection = new System.Data.SqlClient.SqlConnection();
//            connection.ConnectionString = _connectionString;
//            connection.Open();


//            var command = new System.Data.SqlClient.SqlCommand("", connection);
//            command.CommandText = string.Format(@"
//INSERT        INTO    Station(ID, LocationAddress, ObservatoryName, LocationByTWD67, CreateTime)
//VALUES          ('{0}','{1}','{2}','{3}','{4}')
//", station.ID, station.LocationAddress, station.ObservatoryName, station.LocationByTWD67, station.CreateTime.ToString("yyyy/MM/dd"));

//            command.ExecuteNonQuery();


//            connection.Close();
//        }
    }
}
