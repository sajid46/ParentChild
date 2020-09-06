using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crud2_ADONet.EF;

namespace Crud2_ADONet.Controllers
{
    public class JobsController : Controller
    {
        private TaxiBoxEntities db = new TaxiBoxEntities();

        // GET: Jobs
        public ActionResult Index()
        {

            string sqlstr = "select ID, Pickup,Destination, PaxName,PaxMobileNo,         NoOfPassengers,        Fare from Jobs";
            string constr = "Data Source=.\\sqlexpress; initial catalog = taxibox; integrated security= true;";
            DataTable dt = Utilities.getDataSet(constr, sqlstr);
            
            JobModel job = new JobModel();
            var o = dt.AsEnumerable().Select(dr => new JobModel
            {
                ID  = Convert.ToInt32(dr["ID"].ToString()),
                Pickup = dr["Pickup"] != null ? dr["Pickup"].ToString() : "",
                Destination = dr["Pickup"] != null ? dr["Destination"].ToString() : "",
                PaxName = dr["Pickup"] != null ? dr["PaxName"].ToString() : "",
                PaxMobileNo = dr["Pickup"] != null ? dr["PaxMobileNo"].ToString() : "",
                Fare = dr["Pickup"] != null ? dr["Fare"].ToString() : "",
                NoOfPassengers = dr["Pickup"] != null ? dr["NoOfPassengers"].ToString() : ""

            }).ToList();

            return View(o.ToList());
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

        public class JobModel
        {
            public int ID { get; set; }
            public string Pickup { get; set; }
            public string Destination { get; set; }
            public string PaxName { get; set; }
            public string PaxMobileNo { get; set; }
            public string Fare { get; set; }
            public string NoOfPassengers { get; set; }
        }
    }

    public static class Utilities
    {
        public static DataTable getDataSet(string connectionString, string sqlString)
        {

            DataSet ds;
            SqlDataAdapter da;
            SqlCommand cmd;
            try
            {
                string where;



                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //conn.ConnectionString = constr;
                    if (conn.State == ConnectionState.Closed) conn.Open();

                    cmd = new SqlCommand();
                    cmd.CommandText = sqlString;
                    cmd.CommandType = sqlString.IndexOf(" ") != -1 ? CommandType.Text : CommandType.StoredProcedure;
                    cmd.Connection = conn;


                    ds = new DataSet();
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    if (ds != null && ds.Tables[0].Rows.Count > 0) return ds.Tables[0];
                    return null;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                da = null;
                ds = null;
            }
        }
    }
}
