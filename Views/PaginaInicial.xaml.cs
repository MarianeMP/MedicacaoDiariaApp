namespace MedicacaoDiariaApp.Views;

public partial class PaginaInicial : ContentPage
{
    public PaginaInicial()
    {
        InitializeComponent();
    }

    private void Button_ListaMedicamentos(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ListaMedicamentos());

    }

    private void Button_NovoMedicamento(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NovoMedicamento());

    }

    private void Button_NovoHorario(object sender, EventArgs e)
    {
        Navigation.PushAsync(new NovoHorario());

    }
}