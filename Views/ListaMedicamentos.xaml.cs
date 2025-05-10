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

    private async void ExluirMedicamento_Clicked(object sender, EventArgs e)
    {
        try
        {
            MenuItem selecionado = sender as MenuItem;

            ListaMedicamento med = selecionado.BindingContext as ListaMedicamento;

            bool confirm = await DisplayAlert("Tem certeza?", $"ATENÇÃO! Todos os horários do medicamento serão excluídos. " +
                $"Remover o medicamento {med.NomeMedicamento}?", "Sim", "Não");

            if (confirm)
            {
                await App.BancoDeDados.ExcluirMedicamento((int)med.IdMedicamento);
                lista.Remove(med);

                await DisplayAlert("Mensagem", "O Medicamento foi excluído", "OK");
                await Navigation.PushAsync(new ListaMedicamentos());



            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("ERRO", ex.Message, "OK");
        }


    }

    private async void EditarMedicamento_Clicked(object sender, EventArgs e)
    {
       

    }
    private async void ExluirHorario_Clicked(object sender, EventArgs e)
    {
       
    }

    private async void EditarHorario_Clicked(object sender, EventArgs e)
    {
        try
        {
            var menuItem = sender as MenuItem;
            var itemSelecionado = menuItem?.CommandParameter as ListaMedicamento;

            if (itemSelecionado != null)
            {
                var horario = new HorarioMedicamento
                {
                    IdHorario = itemSelecionado.IdHorario ?? 0,
                    IdMedicamento = itemSelecionado.IdMedicamento ?? 0,
                    Dosagem = itemSelecionado.Dosagem,
                    Horario = itemSelecionado.Horario
                };

                await Navigation.PushAsync(new EditarHorario(horario));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }

}