using Paul.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paul.Repository
{
    public class StationRepository
    {
        private string _connectionString= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\GITHUB\homework\3.Web\Web\App_Data\Reservoir.mdf;Integrated Security=True";
 


        public void Create(List<Models.Station> stations)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            foreach (var station in stations)
            {
                var command = new System.Data.SqlClient.SqlCommand("", connection);
                command.CommandText = string.Format(@"
INSERT        INTO    Station(ReservoirName, ReservoirIdentifier, EffectiveCapacity, DeadStorageLevel,FullWaterLevel,CatchmentAreaRainfall, InflowVolume, OutflowTotal)
VALUES          (N'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')
", station.ReservoirName, station.ReservoirIdentifier, station.EffectiveCapacity, station.DeadStorageLevel, station.FullWaterLevel, station.CatchmentAreaRainfall, station.InflowVolume, station.OutflowTotal);

                command.ExecuteNonQuery();
            }



            connection.Close();
        }


        public List<Models.Station> FindAllStations()
        {
            var result = new List<Models.Station>();
            var connection = new System.Data.SqlClient.SqlConnection(_connectionString);
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = @"
Select * from Station";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Models.Station item = new Models.Station();
                item.ReservoirName = reader["ReservoirName"].ToString();
                item.ReservoirIdentifier = reader["ReservoirIdentifier"].ToString();
                item.EffectiveCapacity = reader["EffectiveCapacity"].ToString();
                item.DeadStorageLevel = reader["DeadStorageLevel"].ToString();
                item.FullWaterLevel = reader["FullWaterLevel"].ToString();
                item.CatchmentAreaRainfall = reader["CatchmentAreaRainfall"].ToString();
                item.InflowVolume = reader["InflowVolume"].ToString();
                item.OutflowTotal = reader["OutflowTotal"].ToString();
                //item.CreateTime = DateTime.Parse(reader["CreateTime"].ToString());
                result.Add(item);
            }
            connection.Close();


            return result;
        }

        //public void InsertStation(List<Models.Station> stations)
        //{
        //    Repository.StationRepository db = new Repository.StationRepository();


        //    Console.WriteLine(string.Format("新增{0}筆監測站的資料開始", stations.Count));
        //    stations.ForEach(x =>
        //    {

        //        db.Create(x);


        //    });
        //    Console.WriteLine(string.Format("新增監測站的資料結束"));


        //}

    }
}
