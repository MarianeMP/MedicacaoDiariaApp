using MedicacaoDiariaApp.Models;
using MedicacaoDiariaApp.Helpers;
using Microsoft.Maui.Controls;
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicacaoDiariaApp.Views;

public partial class NovoHorario : ContentPage
{
    private HorarioMedicamento _horarioMedicamento;
    private SQLiteBancoDeDados _bancoDeDados;
    private List<Medicamento> _medicamentosDisponiveis;

    public NovoHorario()
    {
        InitializeComponent();



        _bancoDeDados = App.BancoDeDados;


        _horarioMedicamento = new HorarioMedicamento
        {
            Horario = DateTime.Now
        };
        BindingContext = _horarioMedicamento;


        CarregarMedicamentos();
    }

    private async void CarregarMedicamentos()
    {
        _medicamentosDisponiveis = await _bancoDeDados.ListarMedicamento();
        MedicamentoPicker.ItemsSource = _medicamentosDisponiveis;
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

        await _bancoDeDados.CadastrarHorarioMedicamento(_horarioMedicamento);

        await DisplayAlert("Sucesso", "Horário de medicação salvo com sucesso!", "OK");

        await Navigation.PushAsync(new ListaMedicamentos());
    }
}
