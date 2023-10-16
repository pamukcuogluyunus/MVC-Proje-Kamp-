using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TalentController : Controller
    {
        TalentManager talentManager = new TalentManager(new EfTalentDal());
        // GET: Talent
        public ActionResult Index()
        {
            var result = talentManager.GetTalents();
            return View(result);
        }
        public ActionResult TalentCard()
        {
            var result = talentManager.GetTalents();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            talentManager.Insert(talent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTalent(int id = 0)
        {
            var result = talentManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            talentManager.Update(talent);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTalent(int Id)
        {
            var result = talentManager.GetById(Id);
            talentManager.Delete(result);
            return RedirectToAction("Index");
        }

    }
}