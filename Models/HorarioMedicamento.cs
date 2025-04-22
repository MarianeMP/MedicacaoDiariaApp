using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicacaoDiariaApp.Models
{
    public class HorarioMedicamento
    {
        [PrimaryKey, AutoIncrement]
        public int IdHorario { get; set; }

        public double Dosagem { get; set; }

        public DateTime Horario { get; set; }

        [ForeignKey(nameof(Medicamento.IdMedicamento))]
        public int IdMedicamento { get; set; }


    }
}
