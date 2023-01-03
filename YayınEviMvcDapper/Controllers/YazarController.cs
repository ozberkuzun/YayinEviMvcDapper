using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using YayınEviMvcDapper.Models;

namespace YayınEviMvcDapper.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        public ActionResult Index()
        {
            return View(DP.ReturnList<YazarModel>("YazarlarListele"));
        }


        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@YazarNo", id);
                return View(DP.ReturnList<YazarModel>("YazarNoSirala", param).FirstOrDefault<YazarModel>());
            }
        }


        [HttpPost]
        public ActionResult EY(YazarModel yazars)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YazarNo", yazars.YazarNo);
            param.Add("@YazarAdi", yazars.YazarAdi);
            param.Add("@YazarTür", yazars.YazarTür);


            DP.ExecuteWReturn("YazarEY", param);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YazarNo", id);
            DP.ExecuteWReturn("YazarSil", param);
            return RedirectToAction("Index");
        }
    }
}