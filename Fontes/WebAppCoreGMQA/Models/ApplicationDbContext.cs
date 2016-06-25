using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebAppCoreGMQA.ViewModels.Risco;
using WebAppCoreGMQA.ViewModels.NivelAcesso;
using WebAppCoreGMQA.ViewModels.Ciclo;
using Microsoft.EntityFrameworkCore;

namespace WebAppCoreGMQA.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder builder)
        {
            base.OnModelCreating(builder);  
        }

        public DbSet<RiscoViewModel> RiscoViewModel { get; set; }
        public DbSet<NivelAcessoViewModel> NivelAcessoViewModel { get; set; }
        public DbSet<CicloViewModel> CicloViewModel { get; set; }
    }
}
