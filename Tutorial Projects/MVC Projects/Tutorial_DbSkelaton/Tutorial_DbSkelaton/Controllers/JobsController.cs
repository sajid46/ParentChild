using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tutorial_DbSkelaton.EF;
using Newtonsoft.Json;

namespace Tutorial_DbSkelaton.Controllers
{
    public class JobsController : Controller
    {
        private TaxiBoxEntities db = new TaxiBoxEntities();

        [HttpGet]
        [Route("JobsAjax")]
        public string JobsPartial()
        {
            var o = db.Jobs.ToList().Take(30).OrderBy(d => d.DateTimePickup);
            var v = View("JobsAjax", o);
            return JsonConvert.SerializeObject(o);
        }

        [HttpGet]
        [Route("JobsAjax2")]
        public string JobsAjax()
        {
            var o = db.Jobs.ToList().Take(30).OrderBy(d => d.DateTimePickup);
            return JsonConvert.SerializeObject(o);
        }

        // GET: Jobs
        public ActionResult Index()
        {
            return View(db.Jobs.ToList().Take(30).OrderBy(d => d.DateTimePickup));
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Pickup,Destination,PaxName,PaxEmail,PaxMobileNo,NoOfPassengers,Distance,DurationMinutes,Fare,MeetandGreetCharges,VehicleTypeCharges,OtherCharges,Discount,JobStatus,DateTimePickup,DriverNo,Created,CreatedBy,Updated,UpdatedBy,DeletedFlag,IsPaid,PaymentMethod,VehicleRequiredID,DirverComm,IsMG")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Pickup,Destination,PaxName,PaxEmail,PaxMobileNo,NoOfPassengers,Distance,DurationMinutes,Fare,MeetandGreetCharges,VehicleTypeCharges,OtherCharges,Discount,JobStatus,DateTimePickup,DriverNo,Created,CreatedBy,Updated,UpdatedBy,DeletedFlag,IsPaid,PaymentMethod,VehicleRequiredID,DirverComm,IsMG")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class JobsModel
    {
        public Nullable<int> ID { get; set; }
        public string Pickup { get; set; }
        public string Destination { get; set; }
        public string PaxName { get; set; }
        public string PaxEmail { get; set; }
        public string PaxMobileNo { get; set; }
        public Nullable<int> NoOfPassengers { get; set; }
        public string Distance { get; set; }
        public string DurationMinutes { get; set; }
        public Nullable<double> Fare { get; set; }
        public Nullable<double> MeetandGreetCharges { get; set; }
        public Nullable<double> VehicleTypeCharges { get; set; }
        public Nullable<double> OtherCharges { get; set; }
        public Nullable<double> Discount { get; set; }
        public string JobStatus { get; set; }
        public Nullable<DateTime> DateTimePickup { get; set; }
        public string DriverNo { get; set; }
        public Nullable<DateTime> Created { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<bool> DeletedFlag { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public string PaymentMethod { get; set; }
        public Nullable<int> VehicleRequiredID { get; set; }
        public Nullable<double> DirverComm { get; set; }
        public Nullable<bool> IsMG { get; set; }




    }
}
