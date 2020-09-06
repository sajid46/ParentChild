using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.EF;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureEntities db = new AdventureEntities();
        private string strConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ToString();
        
        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.ProductModel).Include(p => p.ProductDocument).Where(c => c.ProductSubcategoryID != null);
            string sqlstring = @"SELECT TOP (1000) [ProductID]      ,[Name]      ,[ProductNumber]      ,[ProductSubcategoryID]	  
            ,[Color]      ,[StandardCost]      ,[ListPrice], Size, Weight, Style	  FROM [AdventureWorks2012].[Production].[Product] WHERE [ProductSubcategoryID]	is not null AND ProductSubcategoryID in (1,3) ";
            DataSet ds = GetDataSet(sqlstring);

            var products2 = ds.Tables[0].AsEnumerable().Select(dr => new ProductModel2
            {
                ProductID = Convert.ToInt32(dr["ProductID"].ToString()),
                Name = dr["Name"] != null ? dr["Name"].ToString() : "",
                ProductNumber = dr["ProductNumber"] != null ? dr["ProductNumber"].ToString() : "",
                ProductSubcategoryID = dr["ProductSubcategoryID"] != null ? Convert.ToInt32(dr["ProductSubcategoryID"].ToString()) : 0,
                ListPrice = dr["ListPrice"] != null ? Convert.ToDecimal(dr["ListPrice"].ToString()) : 0,
                StandardCost = dr["StandardCost"] != null ? Convert.ToDecimal(dr["StandardCost"].ToString()) : 0,
                Color = dr["Color"] != null ? dr["Color"].ToString() : "",
                Size = dr["Size"] != null ? dr["Size"].ToString() : ""
            }).ToList();
            return View(products2);
            //return View(products.ToList());



        }

        // GET: Products
        public ActionResult AajxIndex()
        {
            var products = db.Products.Include(p => p.ProductModel).Include(p => p.ProductDocument).Where(c => c.ProductSubcategoryID != null);
            string sqlstring = @"SELECT TOP (1000) [ProductID]      ,[Name]      ,[ProductNumber]      ,[ProductSubcategoryID]	  
            ,[Color]      ,[StandardCost]      ,[ListPrice], Size, Weight, Style	  FROM [AdventureWorks2012].[Production].[Product] WHERE [ProductSubcategoryID]	is not null  ";
            DataSet ds = GetDataSet(sqlstring);

            var products2 = ds.Tables[0].AsEnumerable().Select(dr => new ProductModel2
            {
                ProductID = Convert.ToInt32(dr["ProductID"].ToString()),
                Name = dr["Name"] != null ? dr["Name"].ToString() : "",
                ProductNumber = dr["ProductNumber"] != null ? dr["ProductNumber"].ToString() : "",
                ProductSubcategoryID = dr["ProductSubcategoryID"] != null ? Convert.ToInt32(dr["ProductSubcategoryID"].ToString()) : 0,
                ListPrice = dr["ListPrice"] != null ? Convert.ToDecimal(dr["ListPrice"].ToString()) : 0,
                StandardCost = dr["StandardCost"] != null ? Convert.ToDecimal(dr["StandardCost"].ToString()) : 0,
                Color = dr["Color"] != null ? dr["Color"].ToString() : "",
                Size = dr["Size"] != null ? dr["Size"].ToString() : ""
            }).ToList();
            return View(products2);
            //return View(products.ToList());



        }


        private DataSet GetDataSet(string sqlSelectString)
        {
            try
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = strConnectionString;
                if (conn.State == ConnectionState.Closed) conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlSelectString;
                cmd.Connection = conn;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);
                if (dataSet != null && dataSet.Tables[0].Rows.Count > 0) return dataSet;
                return null;

    }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
             
                
            }
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name");
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,Name,ProductNumber,MakeFlag,FinishedGoodsFlag,Color,SafetyStockLevel,ReorderPoint,StandardCost,ListPrice,Size,SizeUnitMeasureCode,WeightUnitMeasureCode,Weight,DaysToManufacture,ProductLine,Class,Style,ProductSubcategoryID,ProductModelID,SellStartDate,SellEndDate,DiscontinuedDate,rowguid,ModifiedDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductModelID = new SelectList(db.ProductModels, "ProductModelID", "Name", product.ProductModelID);
            ViewBag.ProductID = new SelectList(db.ProductDocuments, "ProductID", "ProductID", product.ProductID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
