namespace MauiAppHotel.Views;

public partial class Contato : ContentPage
{
    public Contato()
    {
        InitializeComponent();
    }

    private async void BtnVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}