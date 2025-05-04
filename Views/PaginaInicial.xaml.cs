namespace MedicacaoDiariaApp.Views
{
    public partial class PaginaInicial : ContentPage
    {
        public PaginaInicial()
        {
            InitializeComponent();
        }

        private void Button_ListaMedicamentos(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaMedicamento());
        }

        private void Button_NovoMedicamento(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovoMedicamento());
        }

        private async void Button_NovoHorario(object sender, EventArgs e)
        {
            try
            {
                
                var medicamentoSelecionado = await App.BancoDeDados.ListarMedicamento();

                if (medicamentoSelecionado.Count > 0)
                {
                    
                    int idMedicamento = medicamentoSelecionado[0].IdMedicamento;
                    Navigation.PushAsync(new NovoHorario(idMedicamento));
                }
                else
                {
                    await DisplayAlert("Erro", "Não há medicamentos cadastrados. Cadastre um medicamento primeiro.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
