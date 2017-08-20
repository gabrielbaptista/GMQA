using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.NivelAcesso
{
    [Table("NiveisAcesso")]
    public class NivelAcessoViewModel
    {
        [Key]
        public int IdNivelAcesso { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string DescricaoNivelAcesso { get; set; }

    }
}
