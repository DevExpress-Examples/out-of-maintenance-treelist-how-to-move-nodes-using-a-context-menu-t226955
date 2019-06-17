using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreeListContextMenu.Models;

namespace TreeListContextMenu.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TreeListPartial()
        {
            var model = NorthwindDataProvider.GetEmployees();
            return PartialView("_TreeListPartial", model);
        }

        public ActionResult TreeListMovePartial(int employeeID, int? reportsTo)
        {
            NorthwindDataProvider.MoveEmployee(employeeID, Convert.ToInt32(reportsTo));
            return TreeListPartial();
        }
    }
}