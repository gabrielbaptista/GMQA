using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.NivelAcesso;

namespace WebAppCoreGMQA.Controllers
{
    public class NivelAcessoController : Controller
    {
        private ApplicationDbContext _context;

        public NivelAcessoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: NivelAcessoViewModels
        public IActionResult Index()
        {
            return View(_context.NivelAcessoViewModel.ToList());
        }

        // GET: NivelAcessoViewModels/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NivelAcessoViewModel nivelAcessoViewModel = _context.NivelAcessoViewModel.Single(m => m.IdNivelAcesso == id);
            if (nivelAcessoViewModel == null)
            {
                return NotFound();
            }

            return View(nivelAcessoViewModel);
        }

        // GET: NivelAcessoViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NivelAcessoViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NivelAcessoViewModel nivelAcessoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.NivelAcessoViewModel.Add(nivelAcessoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelAcessoViewModel);
        }

        // GET: NivelAcessoViewModels/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NivelAcessoViewModel nivelAcessoViewModel = _context.NivelAcessoViewModel.Single(m => m.IdNivelAcesso == id);
            if (nivelAcessoViewModel == null)
            {
                return NotFound();
            }
            return View(nivelAcessoViewModel);
        }

        // POST: NivelAcessoViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NivelAcessoViewModel nivelAcessoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(nivelAcessoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nivelAcessoViewModel);
        }

        // GET: NivelAcessoViewModels/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NivelAcessoViewModel nivelAcessoViewModel = _context.NivelAcessoViewModel.Single(m => m.IdNivelAcesso == id);
            if (nivelAcessoViewModel == null)
            {
                return NotFound();
            }

            return View(nivelAcessoViewModel);
        }

        // POST: NivelAcessoViewModels/Delete/5
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                NivelAcessoViewModel nivelAcessoViewModel = _context.NivelAcessoViewModel.Single(m => m.IdNivelAcesso == id);
                _context.NivelAcessoViewModel.Remove(nivelAcessoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (System.Exception)
            {

                return RedirectToAction("Index");
            }
           
        }

        public IActionResult SearchProject(string filtro)
        {
            var search = _context.NivelAcessoViewModel.ToList();

            if (!string.IsNullOrEmpty(filtro))
            {
                search = _context.NivelAcessoViewModel.Where(a => a.DescricaoNivelAcesso.Contains(filtro)).ToList();
            }

            return PartialView(search);
        }
    }
}
