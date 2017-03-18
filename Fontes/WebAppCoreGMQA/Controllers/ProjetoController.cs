using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Ciclo;
using WebAppCoreGMQA.ViewModels.Projeto;
using WebAppCoreGMQA.ViewModels.Risco;
using WebAppCoreGMQA.ViewModels.Usuario;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppCoreGMQA.Controllers
{
    public class ProjetoController : Controller
    {
        private ApplicationDbContext _context;
        public ProjetoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var projetosLista = _context.ProjetoViewModel.ToList().OrderBy(a => a.DataInicio);
            return View(projetosLista);
        }

        public IActionResult Create()
        {
            ViewBag.Usuarios = _context.UsuarioViewModel.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjetoViewModel projetoViewModel)
        {
            if (ModelState.IsValid)
            {
                projetoViewModel.DataReal = DateTime.Now;
                _context.ProjetoViewModel.Add(projetoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projetoViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjetoViewModel projetoViewModel = _context.ProjetoViewModel.SingleOrDefault(m => m.IdProjeto == id);
            ViewBag.Usuarios = _context.UsuarioViewModel.ToList();

            return View(projetoViewModel);
        }

        // POST: ProjetoViewModells/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProjetoViewModel projetoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Update(projetoViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projetoViewModel);
        }

        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProjetoViewModel projetoViewModel = _context.ProjetoViewModel.SingleOrDefault(m => m.IdProjeto == id);
            if (projetoViewModel == null)
            {
                return NotFound();
            }

            return View(projetoViewModel);
        }

        // POST: NivelAcessoViewModels/Delete/5
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {

            var projetos = from p in _context.ProjetoViewModel
                           join c in _context.CicloViewModel on p.IdProjeto equals c.IdProjeto
                           join r in _context.RiscoViewModel on p.IdProjeto equals r.IdProjeto
                           where p.IdProjeto == id

                           select new ProjetoViewModel();

            var deleteProj = projetos.ToList();

            if (deleteProj.Count() == 0)
            {
                _context.Remove(_context.ProjetoViewModel.Where(a => a.IdProjeto == id).FirstOrDefault());
            }

            var ciclos = from c in _context.CicloViewModel
                         join p in _context.ProjetoViewModel on c.IdProjeto equals p.IdProjeto
                         where p.IdProjeto == id

                         select new CicloViewModel();

            var riscos = from r in _context.RiscoViewModel
                         join p in _context.ProjetoViewModel on r.IdProjeto equals p.IdProjeto
                         where p.IdProjeto == id

                         select new RiscoViewModel();

            var deleteCiclo = ciclos.ToList();
            
            var deleteRisco = riscos.ToList();

            if (deleteRisco.Count() != 0)
                _context.RiscoViewModel.RemoveRange(deleteRisco);

            if (deleteCiclo.Count != 0)
                _context.CicloViewModel.RemoveRange(deleteCiclo);

            if (deleteProj.Count != 0)
                _context.ProjetoViewModel.RemoveRange(deleteProj);

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SearchProject(string filtro)
        {
            var search = _context.ProjetoViewModel.Where(a => a.Nome.Contains(filtro)).ToList();

            return PartialView(search);
        }

    }
}
