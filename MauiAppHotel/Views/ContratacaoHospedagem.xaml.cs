namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
    App PropriedadesApp;

    public ContratacaoHospedagem()
    {
        InitializeComponent();

        PropriedadesApp = (App)Application.Current;

        pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

        dtpck_checkin.MinimumDate = DateTime.Now;
        dtpck_checkin.MaximumDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, DateTime.Now.Day);

        dtpck_checkout.MinimumDate = dtpck_checkin.Date.Value.AddDays(1);
        dtpck_checkout.MaximumDate = dtpck_checkin.Date.Value.AddMonths(6);
    }

    private async void ButtonSobre_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Sobre());
    }

    private async void BtnAvancar_Clicked(object sender, EventArgs e)
    {
        if (pck_quarto.SelectedItem == null)
        {
            await DisplayAlert("Atenção", "Por favor, selecione uma acomodação.", "OK");
            return;
        }

        if (stp_adultos.Value == 0)
        {
            await DisplayAlert("Atenção", "É necessário ao menos 1 adulto.", "OK");
            return;
        }

        if (dtpck_checkout.Date <= dtpck_checkin.Date)
        {
            await DisplayAlert("Atenção", "O check-out deve ser após o check-in.", "OK");
            return;
        }

        await Navigation.PushAsync(new HospedagemContratada());
    }

    private async void BtnContato_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Contato());
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime data_selecionada_checkin = (DateTime)elemento.Date;

        dtpck_checkout.MinimumDate = data_selecionada_checkin.AddDays(1);
        dtpck_checkout.MaximumDate = data_selecionada_checkin.AddMonths(6);
    }
}