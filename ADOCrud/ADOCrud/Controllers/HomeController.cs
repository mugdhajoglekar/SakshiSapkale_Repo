namespace ADOCrud.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using ADOCrud.Models;
    using log4net;
    
    public class HomeController : Controller
    {
       // private ILog Logger = LogManager.GetLogger(typeof(HomeController));
        EmployeeRepository db = new EmployeeRepository();
        public ActionResult Index()
        {
            return View(db.GetData());
        }
       
        //Search ID
        public ActionResult Delete(int id)
        {
            //match id with db id
            var row = db.GetData().Find(model => model.Id == id);
            return View();
        }

        // [HttpPost]
        [HttpDelete]
        //DELETE ID
        public ActionResult Delete(Employee obj)
        {
            db.Del(obj);
            return RedirectToAction("Index");//after deleting return to index page
        }

        public ActionResult Edit(int id)
        {
            //match id with db id
            var row = db.GetData().Find(model => model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Employee obj)
        {
            db.update(obj);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee e)
        {
            if (ModelState.IsValid == true)
            {
                db.Add(e);
                if (db != null)
                {
                    ViewBag.AddMsg = "<script>alert('something went wrong')";
                    return RedirectToAction("Index");   
                }
                else
                {
                    ModelState.Clear();
                    ViewBag.AddMsg = "<script>alert('Data saved...')";
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}