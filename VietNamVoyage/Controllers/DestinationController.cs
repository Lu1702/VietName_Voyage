using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VietNamVoyage.Models;

namespace VietNamVoyage.Controllers
{
    public class DestinationController : Controller
    {
        TravelDBEntities db = new TravelDBEntities();
        public ActionResult Destinations()
        {
            var list = db.Destinations.ToList();
            return View(list);
        }

    }
}