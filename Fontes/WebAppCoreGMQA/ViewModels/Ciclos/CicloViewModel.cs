using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Ciclos
{   
    [Table ("Ciclos")]
    public class CicloViewModel
    {
        [Key]
        public int idCiclos { get; set; }

        [Required]
        [Display(Name = "NumeroCiclo")]
        public int NumeroCiclo { get; set; }

        [Required]
        [Display(Name = "FaseCiclo")]
        public string FaseCiclo { get; set; }

        [Required]
        [Display(Name = "DataInicio")]
        public DateTime DataInicio { get; set; }

        [Required]
        [Display(Name = "DataFim")]
        public DateTime DataFim { get; set; }

    }
}
