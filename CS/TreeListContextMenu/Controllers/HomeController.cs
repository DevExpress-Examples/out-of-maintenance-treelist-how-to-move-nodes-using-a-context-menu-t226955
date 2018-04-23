using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TreeListContextMenu.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TreeListPartial()
        {
            return PartialView(NorthwindDataProvider.GetEmployees());
        }

       
        public ActionResult TreeListMovePartial(int employeeID, int? reportsTo)
        {
            NorthwindDataProvider.MoveEmployee(employeeID, Convert.ToInt32(reportsTo));
            return PartialView("TreeListPartial", NorthwindDataProvider.GetEmployees());
        }

        
    }
}
