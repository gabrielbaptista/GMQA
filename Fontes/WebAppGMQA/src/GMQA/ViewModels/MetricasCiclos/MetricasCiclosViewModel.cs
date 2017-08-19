using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppCoreGMQA.ViewModels.MetricasCiclos
{
    [Table("Metricas")]
    public class MetricasCiclosViewModel
    {
        [Key]
        public int IdCicloMetrica { get; set; }

        [Required]
        public int IdCiclo { get; set; }

        [Required]
        public int IdMetrica { get; set; }

        [Required]
        public bool Ativo { get; set; }

        public string DescricaoMetrica { get; set; }
    }
}
