using System;
using WStandSim.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WStandSim
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Overview : ContentPage
    {

        Simulation s;
        Stock stock;
        public Overview()
        {
            InitializeComponent();
            s = new Simulation();
            s.ReturnWeather.ToString();
            BindingContext = s;
            stock = new Stock();
        }

        // Tag starten
        private void Button_ClickedContinue(object sender, EventArgs e)
        {
            // Artikel verkaufen und den Kontostand aktualisieren
            s.Sell();
            s.SimulateNewDayAndSeason(); 
            s.CalculateNewWeather();

            // Felder manuell aktualisieren
            OnAppearing();

            // Abfragen, ob man pleite ist
            if (s.IsBankrupt)
            {
                // Meldung dass man pleite ist
                DisplayGameOverMessage();
                // Instanzieren der Helper-Klasse
                Helper h = new Helper();
                // Aufruf der Initializer / zurücksetzen der Datenbank
                h.Initializer();
                // Zurücksetzen, dass Spiel gespeichert wurde.
                s.IsGameSaved = false;
                // Naviation zum Starbildschirm
                Navigation.PopModalAsync();
            }
        }

        // Navigation zum Lager
        async private void Button_ClickedStock(object sender, EventArgs e)
        {
            if (stock == null)
            {
                stock = new Stock();
                await Navigation.PushModalAsync(stock);
            }
            else
                await Navigation.PushModalAsync(stock);
        }

        // Methode zur Übernahme des Geänderten Guthabens
        protected override void OnAppearing()
        {
            base.OnAppearing();

            CurrBal.Text = s.CurrentBalance.ToString();
            RecYest.Text = s.ReceiptsYesterday.ToString();
            ExpYest.Text = s.ExpendituresYesterday.ToString();
        }

        // Pop-Up für Game Over
        private void DisplayGameOverMessage()
        {
            DisplayAlert("Ojeeeee!", "Du bist pleite!", "Weiter...");
        }
    }
}