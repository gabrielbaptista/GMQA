using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Ciclo;
using WebAppCoreGMQA.ViewModels.Metrica;
using WebAppCoreGMQA.ViewModels.Projeto;
using WebAppCoreGMQA.ViewModels.Risco;
using WebAppCoreGMQA.ViewModels.Usuario;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppCoreGMQA.Controllers
{

    public class MetricaController : Controller
    {
        private ApplicationDbContext _context;
        public MetricaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var matricaLista = _context.MetricaViewModel.ToList().OrderBy(a => a.DescricaoMetrica);
            return View(matricaLista);
        }

        public IActionResult Create()
        {
            ViewBag.IdCiclo = _context.CicloViewModel.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MetricaViewModel metricaViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.MetricaViewModel.Add(metricaViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metricaViewModel);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MetricaViewModel metricaViewModel = _context.MetricaViewModel.SingleOrDefault(m => m.IdMetrica == id);
            ViewBag.IdCiclo = _context.CicloViewModel.ToList();

            return View(metricaViewModel);
        }

        // POST: ProjetoViewModells/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MetricaViewModel metricaViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.MetricaViewModel.Update(metricaViewModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metricaViewModel);
        }

        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MetricaViewModel metricaViewModel = _context.MetricaViewModel.SingleOrDefault(m => m.IdMetrica == id);
            if (metricaViewModel == null)
            {
                return NotFound();
            }

            return View(metricaViewModel);
        }

        // POST: NivelAcessoViewModels/Delete/5
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var metrica = _context.MetricaViewModel.Where(a => a.IdMetrica == id).FirstOrDefault();

            _context.MetricaViewModel.Remove(metrica);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult SearchProject(string filtro)
        {
            var search = _context.MetricaViewModel.Where(a => a.DescricaoMetrica.Contains(filtro)).ToList();

            return PartialView(search);
        }

    }
}
