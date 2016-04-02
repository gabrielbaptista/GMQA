using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Risco
{
    [Table("Riscos")]
    public class RiscoViewModel
    {
        // Chave
        [Key]
        public int IdRisco { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string DescricaoRisco { get; set; }
    }
}
