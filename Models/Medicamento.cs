using SQLite;

namespace MedicacaoDiariaApp.Models
{
    public class Medicamento
    {

        string _nome;
        string _indicacao;


        [PrimaryKey, AutoIncrement]
        public int? IdMedicamento { get; set; }

        public string Nome 
        { get => _nome;
            set 
            {
                _nome = value ?? throw new Exception("Por favor, digite o nome do medicamento!");
            } }
        
        public  string Indicacao
        {
            get => _indicacao;
            set
            {
                _indicacao = value ?? throw new Exception("Por favor, digite a indicação do medicamento!");
            }
        }

    }

}

