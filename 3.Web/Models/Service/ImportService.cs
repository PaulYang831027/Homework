using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Paul.Models;

namespace Paul.Service
{
    public class ImportService
    {
        public List<Station> FindStations(string xmlPath)
        {
            List<Station> stations = new List<Station>();



            var xml = XElement.Load(xmlPath);


            XNamespace gml = @"http://www.opengis.net/gml/3.2";
            XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var stationsNode = xml.Descendants(twed + "DailyOperationalStatisticsOfReservoirs").ToList();
            stationsNode
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationNode =>
                {
                    var ReservoirName = stationNode.Element(twed + "ReservoirName").Value.Trim();
                    var ReservoirIdentifier = stationNode.Element(twed + "ReservoirIdentifier").Value.Trim();
                    //var RecordTime = stationNode.Element(twed + "RecordTime").Value.Trim();
                    var EffectiveCapacity = stationNode.Element(twed + "EffectiveCapacity").Value.Trim();
                    var DeadStorageLevel = stationNode.Element(twed + "DeadStorageLevel").Value.Trim();
                    var FullWaterLevel = stationNode.Element(twed + "FullWaterLevel").Value.Trim();
                    var CatchmentAreaRainfall = stationNode.Element(twed + "CatchmentAreaRainfall").Value.Trim();
                    var InflowVolume = stationNode.Element(twed + "InflowVolume").Value.Trim();
                    //var Outflow = stationNode.Element(twed + "Outflow").Value.Trim();
                    var OutflowTotal = stationNode.Element(twed + "OutflowTotal").Value.Trim();

                    Station stationData = new Station();

                    stationData.ReservoirName = ReservoirName;
                    stationData.ReservoirIdentifier = ReservoirIdentifier;
                    //stationData.RecordTime = RecordTime;
                    stationData.EffectiveCapacity = EffectiveCapacity;
                    stationData.DeadStorageLevel = DeadStorageLevel;
                    stationData.FullWaterLevel = FullWaterLevel;
                    stationData.CatchmentAreaRainfall = CatchmentAreaRainfall;
                    stationData.InflowVolume = InflowVolume;
                    //stationData.Outflow = Outflow;
                    stationData.OutflowTotal = OutflowTotal;
                    //stationData.CreateTime = DateTime.Now;
                    stations.Add(stationData);

                });



            return stations;

        }

        //public  void InsertStation(List<Station> stations)
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
