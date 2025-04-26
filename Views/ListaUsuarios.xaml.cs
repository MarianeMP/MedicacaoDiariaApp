using MedicacaoDiariaApp.Helpers;
using MedicacaoDiariaApp.Models;
using Microsoft.Maui.Controls;

namespace MedicacaoDiariaApp.Views
{
    public partial class ListaUsuarios : ContentPage
    {
        private readonly SQLiteBancoDeDados _db;

        public ListaUsuarios()
        {
            InitializeComponent();

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "medicacao_diaria.db3");
            _db = new SQLiteBancoDeDados(dbPath);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Carrega os usuários do banco
            var usuarios = await _db.ListarUsuarios();
            collectionViewUsuarios.ItemsSource = usuarios;
        }
    }
}
