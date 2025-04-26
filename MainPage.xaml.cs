using MedicacaoDiariaApp.Views;

namespace MedicacaoDiariaApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        // Navegação para a tela inicial (entrar no app)
        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaInicial());
        }

        // Navegação para a tela de cadastro de usuário
        private async void Button_CadastrarUsuario_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NovoUsuario());
        }

        // Navegação para a lista de usuários cadastrados
        private async void Button_VisualizarUsuarios_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaUsuarios());  // Navegação para a ListaUsuarios
        }
    }
}
