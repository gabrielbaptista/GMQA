using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Projeto;
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            ProjetoViewModel projetoViewModel = _context.ProjetoViewModel.Single(m => m.IdProjeto == id);
            _context.ProjetoViewModel.Remove(projetoViewModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
