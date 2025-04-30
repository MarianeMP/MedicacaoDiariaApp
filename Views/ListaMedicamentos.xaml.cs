using System.Collections.ObjectModel;
using MedicacaoDiariaApp.Models;

namespace MedicacaoDiariaApp.Views;

public partial class ListaMedicamentos : ContentPage
{
  ObservableCollection<ListaMedicamento> lista = new ObservableCollection<ListaMedicamento>();
    public ListaMedicamentos()
	{
		InitializeComponent();

         lst_medicamentos.ItemsSource = lista;

    }

    protected async override void OnAppearing()
    {
        lista.Clear();
        List<ListaMedicamento> tmp = await App.BancoDeDados.ListarHorarioMedicamento();

        tmp.ForEach(i => lista.Add(i));
    }

    private void Home_Clicked(object sender, EventArgs e)
    {
        try
        {

            Navigation.PushAsync(new PaginaInicial());


        }
        catch (Exception ex)
        {
            DisplayAlert("ERRO", ex.Message, "OK");
        }
    }

    private void Exluir_Clicked(object sender, EventArgs e)
    {

    }

    private void Editar_Clicked(object sender, EventArgs e)
    {

    }
}