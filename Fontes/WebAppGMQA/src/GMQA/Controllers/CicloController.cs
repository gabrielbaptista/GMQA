using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Ciclo;
using Microsoft.AspNetCore.Identity;

namespace WebAppCoreGMQA.Controllers
{
    [Authorize]
    public class CicloController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CicloController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public string GetIdUserLogado(string email)
        {
            var userId = _userManager.Users.Where(a => a.Email == email).FirstOrDefault();
            return userId.Id;
        }

        // GET: Ciclo
        public IActionResult Index()
        {

            var ciclos = from c in _context.CicloViewModel
                         join p in _context.ProjetoViewModel on c.IdProjeto equals p.IdProjeto
                         join e in _context.EtapaViewModel on c.IdEtapas equals e.IdEtapas
                         where p.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || p.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)
                         select new CicloViewModel
                         {
                             DataFim = c.DataFim,
                             EtapaDesc = e.Descricao,
                             IdEtapas = c.IdEtapas,
                             DataInicio = c.DataInicio,
                             FaseCiclo = c.FaseCiclo,
                             IdCiclos = c.IdCiclos,
                             NumeroCiclo = c.NumeroCiclo,
                             IdProjeto = c.IdProjeto,
                             ProjetoDesc = p.Nome

                         };

            var cicloViewModel = ciclos.OrderBy(a => a.ProjetoDesc).ToList();

            return View(cicloViewModel);
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
            ViewBag.IdProjeto = _context.ProjetoViewModel.Where(a => a.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || a.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)).ToList();
            ViewBag.IdEtapa = _context.EtapaViewModel.ToList();

            ViewBag.Metricas = _context.MetricaViewModel.ToList();

            return View();
        }

        // POST: Ciclo/Create
        [HttpPost]
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

            ViewBag.IdProjeto = _context.ProjetoViewModel.Where(a => a.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || a.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)).ToList();
            ViewBag.IdEtapa = _context.EtapaViewModel.ToList();

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
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            CicloViewModel cicloViewModel = _context.CicloViewModel.Single(m => m.IdCiclos == id);

            var riscos = _context.RiscoViewModel.Where(a => a.IdCiclo == id).ToList();

            if (riscos.Count() != 0)
                _context.RiscoViewModel.RemoveRange(riscos);

            _context.CicloViewModel.Remove(cicloViewModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SearchProject(string filtro)
        {
            var search = _context.CicloViewModel.ToList();

            if (string.IsNullOrEmpty(filtro))
            {
                search = _context.CicloViewModel.Where(a => a.FaseCiclo.Contains(filtro)).ToList();

            }

            return PartialView(search);
        }
    }
}