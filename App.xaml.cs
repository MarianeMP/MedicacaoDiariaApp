using MedicacaoDiariaApp.Views;
using MedicacaoDiariaApp.Helpers;
using MedicacaoDiariaApp.Models;

namespace MedicacaoDiariaApp
{
    public partial class App : Application
    {
        static SQLiteBancoDeDados _bancodedados;

        
        public static SQLiteBancoDeDados BancoDeDados
        {
            get
            {
                if (_bancodedados == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "banco_sqlite_medicamento.db3");
                    _bancodedados = new SQLiteBancoDeDados(path);
                }
            return _bancodedados;
            }
        }
        
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
