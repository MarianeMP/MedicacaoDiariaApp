using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicacaoDiariaApp.Models
{
   public class ListaMedicamento
    {
        public int? IdMedicamento { get; set; }

        public string? NomeMedicamento { get; set; }

        public string? IndicacaoMedicamento { get; set; }

        public int? IdHorario { get; set; }

        public string? Dosagem { get; set; }

        public DateTime Horario { get; set; }

    }
}
