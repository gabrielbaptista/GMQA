using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Projeto
{
    [Table("Projetos")]
    public class ProjetoViewModel
    {
        [Key]
        public int IdProjeto { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Cliente do Projeto")]
        public string ClienteProjeto { get; set; }

        [Required]
        [Display(Name = "Data de Inicio")]
        public DateTime DataInicio { get; set; }
        
        [Required]
        [Display(Name = "Data de Fim ")]
        public DateTime DataFim { get; set; }

        [Required]
        [Display(Name = "Data Real ")]
        public DateTime DataReal { get; set; }

        [Required]
        [Display(Name = "Id do usuário ")]
        public int IdUserResponsavelProjeto { get; set; }

        [Required]
        [Display(Name = "Id do adm ")]
        public int IdUserAdmProjeto { get; set; }

        //public Usuarios

    }
}