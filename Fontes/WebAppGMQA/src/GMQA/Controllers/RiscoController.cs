using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppCoreGMQA.Models;
using WebAppCoreGMQA.ViewModels.Risco;
using Microsoft.AspNetCore.Identity;

namespace WebAppCoreGMQA.Controllers
{
    [Authorize]
    public class RiscoController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RiscoController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public string GetIdUserLogado(string email)
        {
            var userId = _userManager.Users.Where(a => a.Email == email).FirstOrDefault();
            return userId.Id;
        }

        // GET: Risco
        public IActionResult Index()
        {

            var risco = from r in _context.RiscoViewModel
                         join p in _context.ProjetoViewModel on r.IdProjeto equals p.IdProjeto
                         where p.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || p.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)
                         select new RiscoViewModel
                         {
                             IdRisco = r.IdRisco,
                             IdCiclo = r.IdCiclo,
                             IdProjeto = r.IdProjeto,
                             Acao = r.Acao,
                             Categoria = r.Categoria,
                             ResponsavelAcao = r.ResponsavelAcao,
                             DescricaoRisco = r.DescricaoRisco,
                             Status = r.Status,
                             EfeitoOcorrencia = r.EfeitoOcorrencia,
                             ProbabilidadeOcorrencia = r.ProbabilidadeOcorrencia


                         };

            var riscoViewModel = risco.OrderBy(a => a.IdRisco).ToList();

            return View(riscoViewModel);
            //return View(_context.RiscoViewModel.ToList());
        }

        // GET: Risco/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            if (riscoViewModel == null)
            {
                return NotFound();
            }

            return View(riscoViewModel);
        }

        // GET: Risco/Create
        public IActionResult Create()
        {
            ViewBag.Ciclos = _context.CicloViewModel.ToList();
            ViewBag.Projetos = _context.ProjetoViewModel.Where(a => a.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || a.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)).ToList();

            var riscoEfeito = new List<SelectListItem>();

            ViewBag.RiscoEfeito = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = EnumRiscoEfeito.Catastroficos.ToString() },
                new SelectListItem { Value = "2", Text = EnumRiscoEfeito.Serios.ToString() },
                new SelectListItem { Value = "3", Text = EnumRiscoEfeito.Toleraveis.ToString() },
                new SelectListItem { Value = "4", Text = EnumRiscoEfeito.Toleraveis.ToString() }

            };

            ViewBag.Categoria = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = EnumCategoria.Tecnologia.ToString() },
                new SelectListItem {Value = "2", Text = EnumCategoria.Equipe.ToString() },
                new SelectListItem {Value = "3", Text = EnumCategoria.Organizacionais.ToString() },
                new SelectListItem {Value = "4", Text = EnumCategoria.Ferramentas.ToString() },
                new SelectListItem {Value = "5", Text = EnumCategoria.Estimativa.ToString() }
            };

            ViewBag.Status = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = Status.EmAndamento.ToString() },
                new SelectListItem {Value = "2", Text = Status.Sanado.ToString() },
                new SelectListItem {Value = "3", Text = Status.Mitigado.ToString() }

            };

            ViewBag.ProbabilidadeOcorrencia = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = EnumProbabilidadeOcorrencia.Alta.ToString() },
                new SelectListItem {Value = "2", Text = EnumProbabilidadeOcorrencia.Media.ToString() },
                new SelectListItem {Value = "3", Text = EnumProbabilidadeOcorrencia.Baixa.ToString() }
            };

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
                return NotFound();
            }

            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            if (riscoViewModel == null)
            {
                return NotFound();
            }

            ViewBag.Ciclos = _context.CicloViewModel.ToList();
            ViewBag.Projetos = _context.ProjetoViewModel.Where(a => a.IdUserAdmProjeto == GetIdUserLogado(User.Identity.Name) || a.IdUserResponsavelProjeto == GetIdUserLogado(User.Identity.Name)).ToList();

            var riscoEfeito = new List<SelectListItem>();

            ViewBag.RiscoEfeito = new List<SelectListItem>()
            {
                new SelectListItem { Value = "1", Text = EnumRiscoEfeito.Catastroficos.ToString() },
                new SelectListItem { Value = "2", Text = EnumRiscoEfeito.Serios.ToString() },
                new SelectListItem { Value = "3", Text = EnumRiscoEfeito.Toleraveis.ToString() },
                new SelectListItem { Value = "4", Text = EnumRiscoEfeito.Toleraveis.ToString() }

            };

            ViewBag.Categoria = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = EnumCategoria.Tecnologia.ToString() },
                new SelectListItem {Value = "2", Text = EnumCategoria.Equipe.ToString() },
                new SelectListItem {Value = "3", Text = EnumCategoria.Organizacionais.ToString() },
                new SelectListItem {Value = "4", Text = EnumCategoria.Ferramentas.ToString() },
                new SelectListItem {Value = "5", Text = EnumCategoria.Estimativa.ToString() }
            };

            ViewBag.Status = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = Status.EmAndamento.ToString() },
                new SelectListItem {Value = "2", Text = Status.Sanado.ToString() },
                new SelectListItem {Value = "3", Text = Status.Mitigado.ToString() }

            };

            ViewBag.ProbabilidadeOcorrencia = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = EnumProbabilidadeOcorrencia.Alta.ToString() },
                new SelectListItem {Value = "2", Text = EnumProbabilidadeOcorrencia.Media.ToString() },
                new SelectListItem {Value = "3", Text = EnumProbabilidadeOcorrencia.Baixa.ToString() }
            };

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
                return NotFound();
            }

            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            if (riscoViewModel == null)
            {
                return NotFound();
            }

            return View(riscoViewModel);
        }

        // POST: Risco/Delete/5
        [ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            RiscoViewModel riscoViewModel = _context.RiscoViewModel.Single(m => m.IdRisco == id);
            _context.RiscoViewModel.Remove(riscoViewModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult SearchProject(string filtro)
        {
            var search = _context.RiscoViewModel.ToList();

            if (!string.IsNullOrEmpty(filtro))
            {
                search = _context.RiscoViewModel.Where(a => a.DescricaoRisco.Contains(filtro)).ToList();
            }

            return PartialView(search);
        }
    }
}
