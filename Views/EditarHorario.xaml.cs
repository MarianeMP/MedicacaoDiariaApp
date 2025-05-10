using MedicacaoDiariaApp.Helpers;
using MedicacaoDiariaApp.Models;

namespace MedicacaoDiariaApp.Views;

public partial class EditarHorario : ContentPage
{
    private HorarioMedicamento _horarioMedicamento;
    private SQLiteBancoDeDados _bancoDeDados;
    private List<Medicamento> _medicamentosDisponiveis;

    public EditarHorario(HorarioMedicamento horarioExistente)
    {
        InitializeComponent();

        _bancoDeDados = App.BancoDeDados;

        _horarioMedicamento = horarioExistente;
        BindingContext = _horarioMedicamento;

        CarregarMedicamentos();
    }

    private async void CarregarMedicamentos()
    {
        _medicamentosDisponiveis = await _bancoDeDados.ListarMedicamento();
        MedicamentoPicker.ItemsSource = _medicamentosDisponiveis;

        // Seleciona automaticamente o medicamento atual
        MedicamentoPicker.SelectedItem = _medicamentosDisponiveis
            .Find(m => m.IdMedicamento == _horarioMedicamento.IdMedicamento);

        // Ajusta o TimePicker para exibir o horário atual
        HorarioTimePicker.Time = _horarioMedicamento.Horario.Value.TimeOfDay;  // Certifique-se de acessar o valor corretamente
    }

    private async void OnSalvarClicked(object sender, EventArgs e)
    {
        if (MedicamentoPicker.SelectedItem == null || string.IsNullOrWhiteSpace(DosagemEntry.Text))
        {
            await DisplayAlert("Erro", "Por favor, selecione um medicamento e preencha todos os campos.", "OK");
            return;
        }

        var medicamentoSelecionado = (Medicamento)MedicamentoPicker.SelectedItem;
        _horarioMedicamento.IdMedicamento = medicamentoSelecionado.IdMedicamento;
        _horarioMedicamento.Dosagem = DosagemEntry.Text;

        var horaSelecionada = HorarioTimePicker.Time;
        _horarioMedicamento.Horario = DateTime.Today.Add(horaSelecionada);

        // Atualiza o horário no banco de dados
        await _bancoDeDados.AtualizarHorarioMedicamento(_horarioMedicamento);

        await DisplayAlert("Sucesso", "Horário de medicação atualizado com sucesso!", "OK");

        await Navigation.PopAsync(); // Volta para a tela anterior
    }
}
