using System.Linq.Expressions;

namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	App PropiedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();

		PropiedadesApp = (App)Application.Current;

		pck_quarto.ItemsSource = PropiedadesApp.lista_quartos;

		dtpck_checkin.MinimumDate = DateTime.Today;
		dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

		dtpck_checkout.MinimumDate = DateTime.Today.AddDays(1);
		dtpck_checkout.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);
    }

	private async void OnSobreClicked(object? sender, EventArgs e)
	{
		await Navigation.PushAsync(new Sobre());
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new HospedagemContratada());

		} catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
		DatePicker elemento = sender as DatePicker;

		DateTime data_selecionada_checkin = (DateTime)elemento.Date;

		dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
		new DateTime(data_selecionada_checkin.Year, Math.Min(data_selecionada_checkin.Month + 1, 12), data_selecionada_checkin.Day);
    }
}