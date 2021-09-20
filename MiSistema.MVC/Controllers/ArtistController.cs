using MiSistema.Data;
using MiSistema.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiSistema.MVC.Controllers
{
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            ArtistDA artistDA = new ArtistDA();
            var lista = artistDA.Gets();
            return View(lista);
        }

        // GET: Artist/Details/5
        public ActionResult Details(int id)
        {
            ArtistDA artistDA = new ArtistDA();
            var artist = artistDA.GetOne(id);
            return View(artist);
        }

        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            try
            {
                // TODO: Add insert logic here
                ArtistDA artistDA = new ArtistDA();
                artistDA.Insert(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int id)
        {
            ArtistDA artistDA = new ArtistDA();
            var artist = artistDA.GetOne(id);
            return View(artist);
        }

        // POST: Artist/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Artist collection)
        {
            try
            {
                // TODO: Add update logic here
                ArtistDA artistDA = new ArtistDA();
                artistDA.Update(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Artist/Delete/5
        public ActionResult Delete(int id)
        {
            ArtistDA artistDA = new ArtistDA();
            var artist = artistDA.GetOne(id);
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ArtistDA artistDA = new ArtistDA();
                artistDA.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
