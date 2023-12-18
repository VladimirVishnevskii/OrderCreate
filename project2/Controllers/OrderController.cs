using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project2.Models;

namespace project2.Controllers
{
    public class OrderController : Controller
    {
        readonly OrderDbContext db;

        public OrderController()
        {
            db = new OrderDbContext();
        }

        public ActionResult IndexNew()
        {
            var order = db.Orders.ToList().OrderBy(o => o.OrderId); 
            
            return View(order);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("IndexNew");
            }
            return View(order);
        }

        public ActionResult Details(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.OrderId == id);
            if (order == null)
            {
                return View();
            }
            return View(order);
        }
        public ActionResult Delete(int id)
        {
            var order = db.Orders.FirstOrDefault(o => o.OrderId == id);
            return View(order);
        }

        [HttpPost]
        public ActionResult Remove(int orderid)
        {
            var order_remove = db.Orders.Find(orderid);

            if (order_remove != null)
            {
                db.Orders.Remove(order_remove);
                db.SaveChanges();

            }
            return Redirect("IndexNew");

        }

        //public ActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(int id)
        //{
        //    var orderid = db.Orders.Find(id);

        //    if (orderid != null)
        //    {
        //        db.Orders.Update(orderid);
        //        db.SaveChanges();
        //        return RedirectToAction("IndexNew");
        //    }
        //    return View();
        //}
        public ActionResult Edit(int id)
        {
            if (id != null)
            {
                Order? order = db.Orders.FirstOrDefault(p => p.OrderId == id);
                if (order != null) return View(order);
            }
            return View("IndexNew");
        }
        [HttpPost]
        public ActionResult Edit(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
            return RedirectToAction("IndexNew");
        }
    }
}
