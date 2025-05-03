using MedicacaoDiariaApp.Models;
using MedicacaoDiariaApp.Helpers;
namespace MedicacaoDiariaApp.Views;

public partial class EditarMedicamento : ContentPage
{
	public EditarMedicamento()
	{
		InitializeComponent();
	}

	private async void ToolbarItem_Clicked(object sender, EventArgs e)
	{
		try
		{
			Medicamento medicamento_anexado = BindingContext as Medicamento;

			Medicamento med = new Medicamento
			{
				IdMedicamento = medicamento_anexado.IdMedicamento,
				Nome = txt_nome.Text,
				Indicacao = txt_indicacao.Text,

			};

			await App.BancoDeDados.EditarMedicamento(med);
			await DisplayAlert("Sucesso", "Registro Atualizado", "OK");
			await Navigation.PopAsync();

		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops", ex.Message, "OK");
		}
	}
}