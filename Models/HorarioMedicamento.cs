using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicacaoDiariaApp.Models
{
    class HorarioMedicamento
    {
        [PrimaryKey, AutoIncrement]
        public int IdHorario { get; set; }

        public double Dosagem { get; set; }

        public DateTime Horario { get; set; }
    }
}
