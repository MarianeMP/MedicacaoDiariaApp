using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicacaoDiariaApp.Models
{
    class ListaMedicamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int IdUsuario { get; set; }

        public int IdMedicamento { get; set; }

        public int IdHorario { get; set; }
    }
}
