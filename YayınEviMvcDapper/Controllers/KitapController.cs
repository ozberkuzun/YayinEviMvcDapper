using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using YayınEviMvcDapper.Models;

namespace YayınEviMvcDapper.Controllers
{
    public class KitapController : Controller
    {
        // GET: Kitap
        public ActionResult Index()
        {
            return View(DP.ReturnList<KitapModel>("KitaplarListele"));
        }



        [HttpGet]
        public ActionResult EY(int id = 0)
        {
            if (id == 0)
                return View();
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@KitapNo", id);
                return View(DP.ReturnList<KitapModel>("KitapNoSirala", param).FirstOrDefault<KitapModel>());
            }
        }


        [HttpPost]
        public ActionResult EY(KitapModel kitaps)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KitapNo", kitaps.KitapNo);
            param.Add("@KitapAd", kitaps.KitapAd);
            param.Add("@KategoriNo", kitaps.KategoriNo);
            param.Add("@YazarNo", kitaps.YazarNo);
            param.Add("@YayinEviNo", kitaps.YayinEviNo);

            DP.ExecuteWReturn("KitapEY", param);
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id = 0)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@KitapNo", id);
            DP.ExecuteWReturn("KitapSil", param);
            return RedirectToAction("Index");
        }
    }
}