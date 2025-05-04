using SQLite;
using System;

namespace MedicacaoDiariaApp.Models
{
    public class HorarioMedicamento
    {
        [PrimaryKey, AutoIncrement]
        public int IdHorario { get; set; }

        public double Dosagem { get; set; }

        public DateTime Horario { get; set; }

        // Campo de ligação com a tabela Medicamento
        [Indexed]
        public int IdMedicamento { get; set; }
    }
}
