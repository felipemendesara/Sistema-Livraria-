using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using LivrariaMendes.Models;
using Microsoft.AspNet.Authorization;

namespace LivrariaMendes.Controllers
{
    public class LivrariasController : Controller
    {
        private ApplicationDbContext _context;

        public LivrariasController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Livrarias
        public IActionResult Index()
        {
            return View(_context.Livrarias.ToList());
        }

        // GET: Livrarias/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Livrarias livrarias = _context.Livrarias.Single(m => m.IdLivraria == id);
            if (livrarias == null)
            {
                return HttpNotFound();
            }

            return View(livrarias);
        }

        // GET: Livrarias/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public IActionResult Maps(int? id)
        {
            if(id == null)
            {
                return HttpNotFound();
            }
            Livrarias livrarias = _context.Livrarias.Single(m => m.IdLivraria == id);
            if(id == null)
            {
                return HttpNotFound();
            }
            return View(livrarias);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Maps(Livro livro)
        {
            return View(livro);
        }
        // POST: Livrarias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livrarias livrarias)
        {
            if (ModelState.IsValid)
            {
                _context.Livrarias.Add(livrarias);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livrarias);
        }

        // GET: Livrarias/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Livrarias livrarias = _context.Livrarias.Single(m => m.IdLivraria == id);
            if (livrarias == null)
            {
                return HttpNotFound();
            }
            return View(livrarias);
        }

        // POST: Livrarias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Livrarias livrarias)
        {
            if (ModelState.IsValid)
            {
                _context.Update(livrarias);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livrarias);
        }

        // GET: Livrarias/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Livrarias livrarias = _context.Livrarias.Single(m => m.IdLivraria == id);
            if (livrarias == null)
            {
                return HttpNotFound();
            }

            return View(livrarias);
        }

        // POST: Livrarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Livrarias livrarias = _context.Livrarias.Single(m => m.IdLivraria == id);
            _context.Livrarias.Remove(livrarias);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
