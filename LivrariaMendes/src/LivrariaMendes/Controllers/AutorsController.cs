using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using LivrariaMendes.Models;
using Microsoft.AspNet.Authorization;

namespace LivrariaMendes.Controllers
{
    public class AutorsController : Controller
    {
        private ApplicationDbContext _context;

        public AutorsController(ApplicationDbContext context)
        {
            _context = context;    
        }
        [Authorize]
        // GET: Autors
        public IActionResult Index()
        {
            return View(_context.Autor.ToList());
        }
        [Authorize]
        // GET: Autors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Autor autor = _context.Autor.Single(m => m.IdAutor == id);
            if (autor == null)
            {
                return HttpNotFound();
            }

            return View(autor);
        }
        [Authorize]
        // GET: Autors/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Autors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Autor.Add(autor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }
        [Authorize]
        // GET: Autors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Autor autor = _context.Autor.Single(m => m.IdAutor == id);
            if (autor == null)
            {
                return HttpNotFound();
            }
            return View(autor);
        }
        [Authorize]
        // POST: Autors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(autor);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autor);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SMS(Autor autor)
        {
            return View();
        }
        [Authorize]
        // GET: Autors/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Autor autor = _context.Autor.Single(m => m.IdAutor == id);
            if (autor == null)
            {
                return HttpNotFound();
            }

            return View(autor);
        }
        [Authorize]
        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Autor autor = _context.Autor.Single(m => m.IdAutor == id);
            _context.Autor.Remove(autor);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
