using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WhoLetDerHundOut.DAL;
using WhoLetDerHundOut.Models;

namespace WhoLetDerHundOut.Controllers
{
    [Authorize]
    public class BreedController : Controller
    {
        private DogContext db = new DogContext();

        // GET: Breed
        public ActionResult Index()
        {
            return View(db.Breeds.ToList());
        }

        // GET: Breed/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breed breeds = db.Breeds.Find(id);
            if (breeds == null)
            {
                return HttpNotFound();
            }
            return View(breeds);
        }

        // GET: Breed/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Breed/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BreedId,BreedName,Country,Photo")] Breed breeds)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Breeds.Add(breeds);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                
            }
            catch (DataException)
            {
                ModelState.AddModelError("",
                    "Unable to save changes. Try again.");
            }
            return View(breeds);
        }

        // GET: Breed/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Breed breed = db.Breeds.Find(id);
            if (breed == null)
            {
                return HttpNotFound();
            }
            return View(breed);
        }

        // POST: Breed/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BreedId,BreedName,Country,Photo")] Breed breed)
        {
            if (ModelState.IsValid)
                try 
                    {
                        db.Entry(breed).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (DataException)
                {
                    ModelState.AddModelError("",
                   "Unable to save changes. Try again.");
                }
            
            return View(breed);
        }

        // GET: Breed/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessagw = "Delete failed. Try again!";
            }
            Breed breed = db.Breeds.Find(id);
            if (breed == null)
            {
                return HttpNotFound();
            }
            return View(breed);
        }

        // POST: Breed/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Breed breed = db.Breeds.Find(id);
                db.Breeds.Remove(breed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
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
