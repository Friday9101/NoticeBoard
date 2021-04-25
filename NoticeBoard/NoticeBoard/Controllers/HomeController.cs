using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NoticeBoard.Models;
using NoticeBoard.Context;

namespace NoticeBoard.Controllers
{
    // GET: Home
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Details(int id)
        {
            NoticeContext ncc = new NoticeContext();
            NoticeModel b = ncc.allNotice.Single(n => n.ID == id);
            return View(b);
        }


        public ActionResult Index()
        {


            NoticeContext ncc = new NoticeContext();


            int lastId = ncc.allNotice.Last().ID;
            NoticeModel b = ncc.allNotice.Single(n => n.ID == lastId);
            ViewBag.titlez = b.Title_ns;
            ViewBag.messagez = b.Message_ns;
            ViewBag.datez = b.Date_ns.ToShortDateString();
            ViewBag.timez = b.Date_ns.ToShortTimeString();
            ViewBag.idz = b.ID;


            List<NoticeModel> nx = ncc.allNotice.ToList();

            return View(nx);
        }

        public ActionResult Index3()
        {
            return View();
        }

    }


}