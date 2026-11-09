using MauiAppHotel.Views;

namespace MauiAppHotel
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ContratacaoHospedagemPage());
        }
    }
}