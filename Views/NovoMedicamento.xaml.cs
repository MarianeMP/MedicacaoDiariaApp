using System.Collections.ObjectModel;
using MedicacaoDiariaApp.Models;

namespace MedicacaoDiariaApp.Views;

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
        List<Medicamento> tmp = await App.BancoDeDados.ListarMedicamento();

        tmp.ForEach(item => lista.Add(item));
    }

    // M?todo para pesquisar  se j? existe um medicamento com esse nome no Banco de Dados
    public Medicamento PesquisarMedicamento(string nome)
    {
        return lista.FirstOrDefault(med => med.Nome == nome);
    }
    private async void Button_AdicionarMedicamento(object sender, EventArgs e)
    {
        try
        {

            string PesquisarMed = txt_nomeMed.Text;

            // Usando a vari?vel para encontrar se esse medicamento j? existe no sistema
            var MedicamentoLista = PesquisarMedicamento(txt_nomeMed.Text);
            if (MedicamentoLista != null)
            {

                // Medicamento Encontrado
                await DisplayAlert("Aviso!", $"J? existe um medicamento {MedicamentoLista.Nome} cadastrado no sistema!", "OK");
            }
            else
            {
                Medicamento med = new Medicamento
                {
                    Nome = txt_nomeMed.Text,
                    Indicacao = txt_indicacao.Text
                };

                await App.BancoDeDados.CadastrarMedicamento(med);
                await DisplayAlert("Sucesso!", $"O medicamento {med.Nome} foi adicionado!", "OK");
                await Navigation.PushAsync(new NovoHorario());


            }
        }


        catch (Exception ex)
        {
            await DisplayAlert("ERRO", ex.Message, "OK");
        }

    }

}