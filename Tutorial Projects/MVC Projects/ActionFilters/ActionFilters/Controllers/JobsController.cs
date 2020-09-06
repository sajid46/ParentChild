using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ActionFilters.EF;

namespace ActionFilters.Controllers
{
    public class JobsController : Controller
    {
        private TaxiBoxEntities db = new TaxiBoxEntities();

        // GET: Jobs
        public ActionResult Index()
        {
            Job job = new Job();
            List<Job> jobs = new List<Job>();
            foreach (var item in db.Jobs)
            {
                job = new Job();
                job.ID = item.ID;
                job.Pickup = item.Pickup;
                job.Destination = item.Destination;
                job.PaxName = item.PaxEmail;
                job.PaxEmail = item.PaxEmail;
                job.PaxMobileNo = item.PaxMobileNo;
                jobs.Add(job);
            }

            //return View(jobs.ToList());
            return View("jobs22");
        }


        [Route("alljobs")]
        public IList<Job> alljobs()
        {
            if (db.Jobs.Count() > 0)
            {
                Job job;
                List<Job> jobs = new List<Job>();
                foreach (var item in db.Jobs)
                {
                    job = new Job();
                    job.ID = item.ID;
                    job.Pickup = item.Pickup;
                    job.Destination = item.Destination;
                    job.PaxName = item.PaxName;
                    job.PaxEmail = item.PaxEmail;
                    job.PaxMobileNo = item.PaxMobileNo;
                    job.NoOfPassengers = item.NoOfPassengers;
                    job.Distance = item.Distance;
                    job.DurationMinutes = item.DurationMinutes;
                    job.Fare = item.Fare;
                    job.MeetandGreetCharges = item.MeetandGreetCharges;
                    job.VehicleTypeCharges = item.VehicleTypeCharges;
                    job.OtherCharges = item.OtherCharges;
                    job.Discount = item.Discount;
                    job.JobStatus = item.JobStatus;
                    job.DateTimePickup = item.DateTimePickup;
                    job.DriverNo = item.DriverNo;
                    job.Created = item.Created;
                    job.CreatedBy = item.CreatedBy;
                    job.Updated = item.Updated;
                    job.UpdatedBy = item.UpdatedBy;
                    job.DeletedFlag = item.DeletedFlag;
                    job.IsPaid = item.IsPaid;
                    job.PaymentMethod = item.PaymentMethod;
                    job.VehicleRequiredID = item.VehicleRequiredID;
                    job.DirverComm = item.DirverComm;
                    job.IsMG = item.IsMG;
                    jobs.Add(job);
                }

                var o = (from x in jobs select x).ToList();

                return o;
            }
            return null; ;
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
}
