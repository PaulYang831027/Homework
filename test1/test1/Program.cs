using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            var stations = FindStations();
            foreach (var data in stations) {

                Console.WriteLine("水庫名稱: " + data.ReservoirName);
                Console.WriteLine("水庫編號: " + data.ReservoirIdentifier);
                Console.WriteLine("紀錄時間: " + data.RecordTime);
                Console.WriteLine("有效容量: " + data.EffectiveCapacity);
                Console.WriteLine("呆水位: " + data.DeadStorageLevel);
                Console.WriteLine("滿水位: " + data.FullWaterLevel);
                Console.WriteLine("集水區雨量: " + data.CatchmentAreaRainfall);
                Console.WriteLine("進水量: " + data.InflowVolume);
                Console.WriteLine("放流量合計: " + data.Outflow + "\n");


            }
            Console.ReadLine();
        }


        public static List<Station> FindStations()
        {
            List<Station> stations = new List<Station>();



            var xml = XElement.Load(@"C:\Users\Paul\Desktop\xmlData.xml");


            XNamespace gml = @"http://www.opengis.net/gml/3.2";
            XNamespace twed = @"http://twed.wra.gov.tw/twedml/opendata";
            var stationsNode = xml.Descendants(twed + "DailyOperationalStatisticsOfReservoirs").ToList();

            stationsNode
                .Where(x => !x.IsEmpty).ToList()
                .ForEach(stationNode =>
                {


                    var ReservoirName = stationNode.Element(twed + "ReservoirName").Value.Trim();
                    var ReservoirIdentifier = stationNode.Element(twed + "ReservoirIdentifier").Value.Trim();
                    var RecordTime = stationNode.Element(twed + "RecordTime").Value.Trim();
                    var EffectiveCapacity = stationNode.Element(twed + "EffectiveCapacity").Value.Trim();
                    var DeadStorageLevel = stationNode.Element(twed + "DeadStorageLevel").Value.Trim();
                    var FullWaterLevel = stationNode.Element(twed + "FullWaterLevel").Value.Trim();
                    var CatchmentAreaRainfall = stationNode.Element(twed + "CatchmentAreaRainfall").Value.Trim();
                    var InflowVolume = stationNode.Element(twed + "InflowVolume").Value.Trim();
                    var Outflow = stationNode.Element(twed + "Outflow").Value.Trim();
                    var OutflowTotal = stationNode.Element(twed + "OutflowTotal").Value.Trim();
                    
                    Station stationData = new Station();

                    stationData.ReservoirName = ReservoirName;
                    stationData.ReservoirIdentifier = ReservoirIdentifier;
                    stationData.RecordTime = RecordTime;
                    stationData.EffectiveCapacity = EffectiveCapacity;
                    stationData.DeadStorageLevel = DeadStorageLevel;
                    stationData.FullWaterLevel = FullWaterLevel;
                    stationData.CatchmentAreaRainfall = CatchmentAreaRainfall;
                    stationData.InflowVolume = InflowVolume;
                    stationData.Outflow = Outflow;
                    stationData.OutflowTotal = OutflowTotal;
                    //stationData.CreateTime = DateTime.Now;
                    stations.Add(stationData);

                });

            return stations;

        }
    }
}
