using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DemoContentController : Controller
    {
        public ActionResult Index()
        {
            var stationRepository = new Paul.Repository.StationRepository();

            var stations = stationRepository.FindAllStations();
            var message = string.Format("共收到{0}筆監測站的資料<br/>", stations.Count);
            stations.ForEach(x =>
            {
                message += string.Format("水庫名稱：{0}<br/>水庫編號：{1}<br/>有效容量:{2}<br/>呆水位:{3}<br/>滿水位:{4}<br/>集水區雨量:{5}<br/>進水量:{6}<br/>放流量合計:{7}<br/><br/>", x.ReservoirName, x.ReservoirIdentifier, x.EffectiveCapacity, x.DeadStorageLevel, x.FullWaterLevel, x.CatchmentAreaRainfall, x.InflowVolume, x.OutflowTotal);
            });
            return Content(message);
        }
    }
}