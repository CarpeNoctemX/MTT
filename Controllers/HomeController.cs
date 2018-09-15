using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MTT.DAL;
using MTT.ViewModels;


namespace MTT.Controllers
{
    public class HomeController : Controller
    {
        private OrganizationContext db = new OrganizationContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            
            string query = "SELECT JoinDate, COUNT(*) AS PlayerCount "
                + "FROM Person "
                + "WHERE Discriminator = 'Player' "
                + "GROUP BY JoinDate";
            IEnumerable<JoinDateGroup> data = db.Database.SqlQuery<JoinDateGroup>(query);

            return View(data.ToList());
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}