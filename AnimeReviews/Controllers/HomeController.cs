using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnimeReviews.Models;
using System.Data.Entity;

namespace AnimeReviews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Temp()
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                return View(arev.AnimeLists.ToList());
            }

        }

        [Authorize]
        public ActionResult Details()
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                return View(arev.AnimeLists.ToList());
            }
                
        }

        [HttpGet, Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, Authorize]
        public ActionResult Create(AnimeList anime)
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                arev.AnimeLists.Add(anime);
                arev.SaveChanges();
            }
            return RedirectToAction("Details");
        }

        public ActionResult Display(int id)
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                return View(arev.AnimeLists.Where(x => x.id == id).FirstOrDefault());
            }
        }

        [HttpGet, Authorize]
        public ActionResult Delete(int id)
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                return View(arev.AnimeLists.Where(x => x.id == id).FirstOrDefault());
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteRecord(int id)
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                var ani_rec = arev.AnimeLists.Where(x => x.id == id).FirstOrDefault();
                arev.AnimeLists.Remove(ani_rec);
                arev.SaveChanges();
                return RedirectToAction("Details");
            }
        }

        [HttpGet, Authorize]
        public ActionResult Edit(int id)
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                return View(arev.AnimeLists.Where(x => x.id == id).FirstOrDefault());
            }
        }

        [HttpPost]
        public ActionResult Edit(AnimeList alist)
        {
            using (AnimeReviewsEntities arev = new AnimeReviewsEntities())
            {
                if (ModelState.IsValid)
                {
                    arev.Entry(alist).State = EntityState.Modified;
                    arev.SaveChanges();
                    return RedirectToAction("Details");
                }
            }
            return View(alist);
        }
    }
}