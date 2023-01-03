using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using YayınEviMvcDapper.Models;

namespace YayınEviMvcDapper.Controllers
{
    public class YayinEviController : Controller
    {
        // GET: YayinEvi
        public ActionResult Index()
        {
            return View(DP.ReturnList<YayinEviModel>("YayinEviListele"));
        }


        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@YayinEviNo", id);
                return View(DP.ReturnList<YayinEviModel>("YayinEviNoSirala", param).FirstOrDefault<YayinEviModel>());
            }
        }


        [HttpPost]
        public ActionResult EY(YayinEviModel yayinevis)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YayinEviNo", yayinevis.YayinEviNo);
            param.Add("@YayinEviAdi", yayinevis.YayinEviAdi);
            param.Add("@YayinEviAdresi", yayinevis.YayinEviAdresi);


            DP.ExecuteWReturn("YayinEviEY", param);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@YayinEviNo", id);
            DP.ExecuteWReturn("YayinEviSil", param);
            return RedirectToAction("Index");
        }

    }
}