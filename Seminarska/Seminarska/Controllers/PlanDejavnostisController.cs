using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Seminarska.Models;

namespace Seminarska.Controllers
{
    public class PlanDejavnostisController : Controller
    {
        private Entities db = new Entities();

        // GET: PlanDejavnostis
        public ActionResult Index()
        {
            var planDejavnosti = db.PlanDejavnosti.Include(p => p.Področja);
            return View(planDejavnosti.ToList());
        }

        // GET: PlanDejavnostis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDejavnosti planDejavnosti = db.PlanDejavnosti.Find(id);
            if (planDejavnosti == null)
            {
                return HttpNotFound();
            }
            return View(planDejavnosti);
        }

        // GET: PlanDejavnostis/Create
        public ActionResult Create()
        {
            ViewBag.PlaPodročje = new SelectList(db.Področja, "PodID", "PodIme");
            return View();
        }

        // POST: PlanDejavnostis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlaId,PlaOpis,PlaŠtDijakov,PlaCilji,PlaTrajanje,PlaPodročje")] PlanDejavnosti planDejavnosti)
        {
            if (ModelState.IsValid)
            {
                db.PlanDejavnosti.Add(planDejavnosti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlaPodročje = new SelectList(db.Področja, "PodID", "PodIme", planDejavnosti.PlaPodročje);
            return View(planDejavnosti);
        }

        // GET: PlanDejavnostis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDejavnosti planDejavnosti = db.PlanDejavnosti.Find(id);
            if (planDejavnosti == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlaPodročje = new SelectList(db.Področja, "PodID", "PodIme", planDejavnosti.PlaPodročje);
            return View(planDejavnosti);
        }

        // POST: PlanDejavnostis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlaId,PlaOpis,PlaŠtDijakov,PlaCilji,PlaTrajanje,PlaPodročje")] PlanDejavnosti planDejavnosti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planDejavnosti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlaPodročje = new SelectList(db.Področja, "PodID", "PodIme", planDejavnosti.PlaPodročje);
            return View(planDejavnosti);
        }

        // GET: PlanDejavnostis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlanDejavnosti planDejavnosti = db.PlanDejavnosti.Find(id);
            if (planDejavnosti == null)
            {
                return HttpNotFound();
            }
            return View(planDejavnosti);
        }

        // POST: PlanDejavnostis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlanDejavnosti planDejavnosti = db.PlanDejavnosti.Find(id);
            db.PlanDejavnosti.Remove(planDejavnosti);
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
