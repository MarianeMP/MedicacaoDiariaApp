using Microsoft.Maui.Controls;
using System;
using MedicacaoDiariaApp.Helpers;
using MedicacaoDiariaApp.Models;
using System.IO;

namespace MedicacaoDiariaApp.Views
{
    public partial class EditarHorario : ContentPage
    {
        private SQLiteBancoDeDados _bancoDeDados;
        private HorarioMedicamento _horarioMedicamento;

        public EditarHorario(HorarioMedicamento horarioMedicamento)
        {
            InitializeComponent();


            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "medicacaodiaria.db3");
            _bancoDeDados = new SQLiteBancoDeDados(dbPath);

            _horarioMedicamento = horarioMedicamento;

          
            MedicamentoEntry.Text = _horarioMedicamento.IdMedicamento.ToString();
            DosagemEntry.Text = _horarioMedicamento.Dosagem.ToString();
            HorarioTimePicker.Time = _horarioMedicamento.Horario.TimeOfDay;
        }

        
        private async void OnSalvarAlteracoesClicked(object sender, EventArgs e)
        {
            
            _horarioMedicamento.Dosagem = Convert.ToDouble(DosagemEntry.Text);
            _horarioMedicamento.Horario = DateTime.Today.Add(HorarioTimePicker.Time); 

            
            await _bancoDeDados.EditarHorarioMedicamento(_horarioMedicamento);

            
            await DisplayAlert("Sucesso", "Horário de medicação atualizado!", "OK");

            
            await Navigation.PopAsync();
        }
    }
}
