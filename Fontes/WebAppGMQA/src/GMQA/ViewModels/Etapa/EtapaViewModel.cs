using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Etapa
{   
    [Table ("Etapas")]
    public class EtapaViewModel
    {
        [Key]
        public int IdEtapas { get; set; }

        [Required]
        [Display(Name = "Etapa")]
        public string Descricao { get; set; }
    }
}
