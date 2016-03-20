using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Risco;

namespace WebAppCoreGMQA.Controllers
{
    public class RiscoController : Controller
    {
        private ApplicationDbContext _context;

        public RiscoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Risco
        public IActionResult Index()
        {
            return View(_context.RiscoViewModel.ToList());
        }

        // GET: Risco/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            if (riscoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(riscoViewModel);
        }

        // GET: Risco/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Risco/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RiscoViewModel riscoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.RiscoViewModel.Add(riscoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riscoViewModel);
        }

        // GET: Risco/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            if (riscoViewModel == null)
            {
                return HttpNotFound();
            }
            return View(riscoViewModel);
        }

        // POST: Risco/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RiscoViewModel riscoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(riscoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riscoViewModel);
        }

        // GET: Risco/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            if (riscoViewModel == null)
            {
                return HttpNotFound();
            }

            return View(riscoViewModel);
        }

        // POST: Risco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            _context.RiscoViewModel.Remove(riscoViewModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
