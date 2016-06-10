using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using WebAppCoreGMQA.ViewModels.Risco;
using WebAppCoreGMQA.ViewModels.NivelAcesso;
using WebAppCoreGMQA.ViewModels.Ciclo;

namespace WebAppCoreGMQA.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<RiscoViewModel> RiscoViewModel { get; set; }
        public DbSet<NivelAcessoViewModel> NivelAcessoViewModel { get; set; }
        public DbSet<CicloViewModel> CicloViewModel { get; set; }
    }
}
