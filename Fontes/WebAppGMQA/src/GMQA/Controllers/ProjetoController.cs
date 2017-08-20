using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Ciclo;
using WebAppCoreGMQA.ViewModels.Projeto;
using WebAppCoreGMQA.ViewModels.Risco;
using WebAppCoreGMQA.ViewModels.Usuario;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppCoreGMQA.Controllers
{

    [Authorize]
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
            var projeto = _context.ProjetoViewModel.Where(a => a.IdProjeto == id).FirstOrDefault();

            var ciclos = _context.CicloViewModel.Where(a => a.IdProjeto == id).ToList();

            var riscos = _context.RiscoViewModel.Where(a => a.IdProjeto == id).ToList();

            if (riscos.Count() != 0)
                _context.RiscoViewModel.RemoveRange(riscos);

            if (ciclos.Count() != 0)
                _context.CicloViewModel.RemoveRange(ciclos);

            _context.ProjetoViewModel.Remove(projeto);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SearchProject(string filtro)
        {
            var search = _context.ProjetoViewModel.Where(a => a.Nome.Contains(filtro)).ToList();

            return PartialView(search);
        }

        public JsonResult RetornQntProd()
        {
            int aprovado = 0, andamento = 0, cancelado = 0, parado = 0;

            var tdsProjeto = _context.ProjetoViewModel.ToList();

            foreach (var item in tdsProjeto)
            {
                if (item.Status == "Aprovado")
                    aprovado++;

                else if (item.Status == "anda")
                    andamento++;

                else if (item.Status == "canc")
                    cancelado++;

                else
                    parado++;

            }

            return Json(new { aprovado = aprovado, andamento = andamento, cancelado = cancelado, parado = parado });
        }
    }
}
