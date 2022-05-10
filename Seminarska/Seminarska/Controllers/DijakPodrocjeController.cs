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
    public class DijakPodrocjeController : Controller
    {
        private Entities db = new Entities();

        // GET: DijakPodrocje
        public ActionResult Index()
        {
            var dijakPodročje = db.DijakPodročje.Include(d => d.Dijak).Include(d => d.Področja);
            return View(dijakPodročje.ToList());
        }

        // GET: DijakPodrocje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DijakPodročje dijakPodročje = db.DijakPodročje.Find(id);
            if (dijakPodročje == null)
            {
                return HttpNotFound();
            }
            return View(dijakPodročje);
        }

        // GET: DijakPodrocje/Create
        public ActionResult Create()
        {
            ViewBag.DijID = new SelectList(db.Dijak, "DijID", "DijIme");
            ViewBag.PodID = new SelectList(db.Področja, "PodID", "PodIme");
            return View();
        }

        // POST: DijakPodrocje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DijID,PodID,DijPodTest")] DijakPodročje dijakPodročje)
        {
            if (ModelState.IsValid)
            {
                db.DijakPodročje.Add(dijakPodročje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DijID = new SelectList(db.Dijak, "DijID", "DijIme", dijakPodročje.DijID);
            ViewBag.PodID = new SelectList(db.Področja, "PodID", "PodIme", dijakPodročje.PodID);
            return View(dijakPodročje);
        }

        // GET: DijakPodrocje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DijakPodročje dijakPodročje = db.DijakPodročje.Find(id);
            if (dijakPodročje == null)
            {
                return HttpNotFound();
            }
            ViewBag.DijID = new SelectList(db.Dijak, "DijID", "DijIme", dijakPodročje.DijID);
            ViewBag.PodID = new SelectList(db.Področja, "PodID", "PodIme", dijakPodročje.PodID);
            return View(dijakPodročje);
        }

        // POST: DijakPodrocje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DijID,PodID,DijPodTest")] DijakPodročje dijakPodročje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dijakPodročje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DijID = new SelectList(db.Dijak, "DijID", "DijIme", dijakPodročje.DijID);
            ViewBag.PodID = new SelectList(db.Področja, "PodID", "PodIme", dijakPodročje.PodID);
            return View(dijakPodročje);
        }

        // GET: DijakPodrocje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DijakPodročje dijakPodročje = db.DijakPodročje.Find(id);
            if (dijakPodročje == null)
            {
                return HttpNotFound();
            }
            return View(dijakPodročje);
        }

        // POST: DijakPodrocje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DijakPodročje dijakPodročje = db.DijakPodročje.Find(id);
            db.DijakPodročje.Remove(dijakPodročje);
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
