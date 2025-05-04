using MedicacaoDiariaApp.Models;
using System;

namespace MedicacaoDiariaApp.Views
{
    public partial class NovoHorario : ContentPage
    {
        private int _idMedicamento; // Variável para armazenar o ID do medicamento

        public NovoHorario(int idMedicamento)
        {
            InitializeComponent();
            _idMedicamento = idMedicamento; // Recebe o ID do medicamento
        }

        private async void Button_SalvarHorario(object sender, EventArgs e)
        {
            try
            {
                // Verificar se os campos estão preenchidos
                if (string.IsNullOrWhiteSpace(txt_dosagem.Text) || timePicker_horario.Time == null)
                {
                    await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                    return;
                }

                // Verificar se a dosagem é um número válido
                if (!double.TryParse(txt_dosagem.Text, out double dosagem) || dosagem <= 0)
                {
                    await DisplayAlert("Erro", "Por favor, insira uma dosagem válida.", "OK");
                    return;
                }

                // Criar o objeto HorarioMedicamento
                HorarioMedicamento novoHorario = new HorarioMedicamento
                {
                    IdMedicamento = _idMedicamento, // Atribuir o id do medicamento recebido
                    Dosagem = dosagem,
                    Horario = DateTime.Today.Add(timePicker_horario.Time) // Configura o horário com a hora selecionada
                };

                // Inserir o novo horário no banco de dados
                var resultado = await App.BancoDeDados.CadastrarHorarioMedicamento(novoHorario);

                if (resultado > 0)
                {
                    await DisplayAlert("Sucesso", "Horário de medicação cadastrado com sucesso!", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Erro ao cadastrar o horário de medicação.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
