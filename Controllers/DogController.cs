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
using PagedList;
using System.Data.Entity.Infrastructure;

namespace WhoLetDerHundOut.Controllers
{
    [Authorize]
    public class DogController : Controller
    {
        private DogContext db = new DogContext();


        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.BreedSortParm = sortOrder == "Breed" ? "breed_desc" : "Breed";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var dog = from d in db.Dogs
                           select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                dog = dog.Where(d => d.nickName.Contains(searchString)
                                                                  || d.Breed.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    dog = dog.OrderByDescending(d => d.nickName);
                    break;
                case "Breed":
                    dog = dog.OrderBy(d => d.Breed);
                    break;
                case "breed_desc":
                    dog = dog.OrderByDescending(d => d.Breed);
                    break;
                default:
                    dog = dog.OrderBy(d => d.nickName);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(dog.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDisplay([Bind(Include = "DogId,nickName,Breed")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Display");
            }
            return View(dog);
        }
        public ActionResult EditDisplay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // GET: Dog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // GET: Dog/Create
        public ActionResult Create()
        {
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName");
            return View();
        }

        // POST: Dog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DogId,UserId,nickName,Breed,BreedId")] Dog dog)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Dogs.Add(dog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("",
                   "Unable to save changes. Try again.");
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", dog.BreedId);
            return View(dog);
        }

        // GET: Dog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", dog.BreedId);
            return View(dog);
        }

        // POST: Dog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DogId,UserId,nickName,Breed,BreedId")] Dog dog)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(dog).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("",
                   "Unable to save changes. Try again.");
                }
            }
            ViewBag.BreedId = new SelectList(db.Breeds, "BreedId", "BreedName", dog.BreedId);
            return View(dog);
        }

        // GET: Dog/Delete/5
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
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        // POST: Dog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Dog dog = db.Dogs.Find(id);
                db.Dogs.Remove(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException)
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

        public ActionResult Display()
        {
            return View(db.Dogs.ToList());
        }
    }
}
