using SQLite;

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
