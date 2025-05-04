using MedicacaoDiariaApp.Helpers;
using MedicacaoDiariaApp.Models;
using Microsoft.Maui.Controls;
using System.IO;

namespace MedicacaoDiariaApp.Views  
{
    public partial class NovoUsuario : ContentPage  // Atualizei o nome para 'NovoUsuario'
    {
        private readonly SQLiteBancoDeDados _db;

        public NovoUsuario()
        {
            InitializeComponent();
            // Definindo o caminho do banco de dados
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "medicacao_diaria.db3");
            _db = new SQLiteBancoDeDados(dbPath);
        }

        // Método para salvar o usuário no banco
        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            // Validar se os campos estão preenchidos
            if (string.IsNullOrWhiteSpace(txt_nome_usuario.Text) || string.IsNullOrWhiteSpace(txt_idade_usuario.Text))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Criar o objeto usuário
            var novoUsuario = new Usuario
            {
                Nome = txt_nome_usuario.Text,
                Idade = int.Parse(txt_idade_usuario.Text)  // Conversão para inteiro
            };

            // Cadastrar no banco de dados
            await _db.CadastrarUsuario(novoUsuario);

            // Exibir uma mensagem de sucesso
            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");

            // Voltar para a página anterior
            await Navigation.PopAsync();
        }
    }
}
