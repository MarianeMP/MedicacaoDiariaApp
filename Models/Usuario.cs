using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicacaoDiariaApp.Models
{
   public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Idade { get; set; }

        public string Nome { get; set; }

    }
}
