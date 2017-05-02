using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paul.Models;

namespace Paul
{
    class Program
    {
        static void setDBFilePath()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relative = @"..\..\App_Data\";
            string absolute = Path.GetFullPath(Path.Combine(baseDirectory, relative));
            AppDomain.CurrentDomain.SetData("DataDirectory", absolute);
        }

        static void Main(string[] args)
        {
            setDBFilePath();
            var import = new Paul.Service.ImportService();
            var db = new Paul.Repository.StationRepository();

           // var stations = import.FindStations(@"C:\Users\Paul\Desktop\xmlData.xml");

            //var stations = import.FindStations(@"d:\THBRM.xml");

            //stations
            //    .ToList().ForEach(station =>
            //{
            //    db.Create(station);
            //});

           var stations = db.FindAllStations();
           /* db.Create(stations);

            foreach (var data in stations)
            {
                //db.Create(stations);

                Console.WriteLine("水庫名稱: " + data.ReservoirName);
                Console.WriteLine("水庫編號: " + data.ReservoirIdentifier);
                //Console.WriteLine("紀錄時間: " + data.RecordTime);
                Console.WriteLine("有效容量: " + data.EffectiveCapacity);
                Console.WriteLine("呆水位: " + data.DeadStorageLevel);
                Console.WriteLine("滿水位: " + data.FullWaterLevel);
                Console.WriteLine("集水區雨量: " + data.CatchmentAreaRainfall);
                Console.WriteLine("進水量: " + data.InflowVolume);
                Console.WriteLine("放流量合計: " + data.OutflowTotal + "\n");


            }*/

            ShowStation(stations);
           
            Console.ReadKey();
           
        }

        public static void ShowStation(List<Station> stations)
        {

            Console.WriteLine(string.Format("共收到{0}筆監測站的資料", stations.Count));
            stations.ForEach(x =>
            {
                //Console.WriteLine(string.Format("站點名稱：{0},地址:{1}", x.ObservatoryName, x.LocationAddress));

                Console.WriteLine(string.Format("水庫名稱：{0}\n水庫編號：{1}\n有效容量:{2}\n呆水位:{3}\n滿水位:{4}\n集水區雨量:{5}\n進水量:{6}\n放流量合計:{7}\n\n", x.ReservoirName, x.ReservoirIdentifier, x.EffectiveCapacity, x.DeadStorageLevel, x.FullWaterLevel, x.CatchmentAreaRainfall, x.InflowVolume, x.OutflowTotal));
            });


        }

        //public void InsertStation(List<Station> stations)
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
