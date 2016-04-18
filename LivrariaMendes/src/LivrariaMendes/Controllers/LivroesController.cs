using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using LivrariaMendes.Models;
using Microsoft.AspNet.Authorization;

namespace LivrariaMendes.Controllers
{
    public class LivroesController : Controller
    {
           
        private ApplicationDbContext _context;

        public LivroesController(ApplicationDbContext context)
        {
            _context = context;    
        }
        [Authorize]
        // GET: Livroes
        public IActionResult Index()
        {
            var applicationDbContext = _context.Livro.Include(l => l.Autor);
            return View(applicationDbContext.ToList());
        }
        [Authorize]
        // GET: Livroes/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Livro livro = _context.Livro.Single(m => m.IdLivro == id);
            if (livro == null)
            {
                return HttpNotFound();
            }

            return View(livro);
        }
        
        [Authorize]
        // GET: Livroes/Create
        public IActionResult Create()
        {
            var autor = new SelectList(_context.Set<Autor>(), "IdAutor", "Nome");
            ViewBag.Autor = autor;
            return View();
        }
        [Authorize]
        // POST: Livroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Livro.Add(livro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["IdAutor"] = new SelectList(_context.Set<Autor>(), "IdAutor", "Nome", livro.IdAutor);
            return View(livro);
        }
        [Authorize]
        // GET: Livroes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Livro livro = _context.Livro.Single(m => m.IdLivro == id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewData["IdAutor"] = new SelectList(_context.Set<Autor>(), "IdAutor", "Autor", livro.IdAutor);
            return View(livro);
        }
        [Authorize]
        // POST: Livroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Update(livro);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["IdAutor"] = new SelectList(_context.Set<Autor>(), "IdAutor", "Autor", livro.IdAutor);
            return View(livro);
        }
        [Authorize]
        // GET: Livroes/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Livro livro = _context.Livro.Single(m => m.IdLivro == id);
            if (livro == null)
            {
                return HttpNotFound();
            }

            return View(livro);
        }
        [Authorize]
        // POST: Livroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Livro livro = _context.Livro.Single(m => m.IdLivro == id);
            _context.Livro.Remove(livro);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
