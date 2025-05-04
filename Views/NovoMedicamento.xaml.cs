using System.Collections.ObjectModel;
using MedicacaoDiariaApp.Models;

namespace MedicacaoDiariaApp.Views
{
    public partial class NovoMedicamento : ContentPage
    {
        ObservableCollection<Medicamento> lista = new ObservableCollection<Medicamento>();

        public NovoMedicamento()
        {
            InitializeComponent();
        }

        // Gerar Lista do Banco de Dados 
        protected async override void OnAppearing()
        {
            lista.Clear();
            var tmp = await App.BancoDeDados.ListarMedicamento();
            tmp.ForEach(item => lista.Add(item));
        }

        // Método para pesquisar se já existe um medicamento com esse nome no Banco de Dados
        public async Task<Medicamento> PesquisarMedicamento(string nome)
        {
            var medicamento = await App.BancoDeDados.ListarMedicamento();
            return medicamento.FirstOrDefault(med => med.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }

        private async void Button_AdicionarMedicamento(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_nomeMed.Text) || string.IsNullOrWhiteSpace(txt_indicacao.Text))
                {
                    await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                    return;
                }

                string nomeMedicamento = txt_nomeMed.Text;
                var medicamentoExistente = await PesquisarMedicamento(nomeMedicamento);

                if (medicamentoExistente != null)
                {
                    await DisplayAlert("Aviso!", $"O medicamento {medicamentoExistente.Nome} já está cadastrado no sistema!", "OK");
                }
                else
                {
                    Medicamento med = new Medicamento
                    {
                        Nome = nomeMedicamento,
                        Indicacao = txt_indicacao.Text
                    };

                    await App.BancoDeDados.CadastrarMedicamento(med);

                    await DisplayAlert("Sucesso!", $"O medicamento {med.Nome} foi adicionado!", "OK");

                    // Passando o idMedicamento para a página NovoHorario
                    await Navigation.PushAsync(new NovoHorario(med.IdMedicamento)); // Passa o id do medicamento
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
