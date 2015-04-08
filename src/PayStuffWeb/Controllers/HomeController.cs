namespace PayStuffWeb.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using FizzWare.NBuilder;
    using PayStuffLib.Benefits;

    public class HomeController : Controller
    {
        private readonly List<BenefitsCost> benefits;

        public HomeController()
        {
            benefits = Builder<BenefitsCost>
                .CreateListOfSize(5)
                .Build().ToList();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(benefits);
        }
    } 
}
