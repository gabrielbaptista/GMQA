using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Ciclo;

namespace WebAppCoreGMQA.Controllers
{
    public class CicloController : Controller
    {
        private ApplicationDbContext _context;

        public CicloController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Ciclo
        public IActionResult Index()
        {
            return View(_context.CicloViewModel.ToList());
        }

        // GET: Ciclo/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CicloViewModel cicloViewModel = _context.CicloViewModel.Single(m => m.IdCiclos == id);
            if (cicloViewModel == null)
            {
                return NotFound();
            }

            return View(cicloViewModel);
        }

        // GET: Ciclo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciclo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CicloViewModel cicloViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.CicloViewModel.Add(cicloViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cicloViewModel);
        }

        // GET: Ciclo/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CicloViewModel cicloViewModel = _context.CicloViewModel.Single(m => m.IdCiclos == id);
            if (cicloViewModel == null)
            {
                return NotFound();
            }
            return View(cicloViewModel);
        }

        // POST: Ciclo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CicloViewModel cicloViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cicloViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cicloViewModel);
        }

        // GET: Ciclo/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CicloViewModel cicloViewModel = _context.CicloViewModel.Single(m => m.IdCiclos == id);
            if (cicloViewModel == null)
            {
                return NotFound();
            }

            return View(cicloViewModel);
        }

        // POST: Ciclo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            CicloViewModel cicloViewModel = _context.CicloViewModel.Single(m => m.IdCiclos == id);
            _context.CicloViewModel.Remove(cicloViewModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
