using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.Metrica
{
    [Table("Metricas")]
    public class MetricaViewModel
    {
        [Key]
        public int IdMetrica { get; set; }

        [Required]
        [Display(Name = "Descrição da Metrica")]
        public string DescricaoMetrica { get; set; }

        [NotMapped]
        public string Ativo { get; set; }
    }
}
