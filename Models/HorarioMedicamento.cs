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
        DateTime _horario;
        string _dosagem;

        [PrimaryKey, AutoIncrement]
        public int IdHorario { get; set; }

        public string? Dosagem
        {
            get => _dosagem;
            set
            {
                _dosagem = value ?? throw new Exception("Por favor, adicione uma dosagem para o medicamento!");
            }
        }

        public DateTime? Horario
        {
            get => _horario;
            set
            {
                _horario = value ?? throw new Exception("Por favor, adicione um horário para o medicamento!");
            }
        }


        [ForeignKey(nameof(Medicamento.IdMedicamento))]
        public int IdMedicamento { get; set; }
    }
}
