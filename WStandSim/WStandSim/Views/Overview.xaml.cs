using System;
using WStandSim.Helpers;
using WStandSim.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WStandSim
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Overview : ContentPage
    {

        Simulation s;
        Stock stock;
        Accounting accounting;
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
            // Button deaktivieren
            IsEnabled = false;
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
            // Button aktivieren
            IsEnabled = true;
        }

        // Navigation zum Lager
        async private void Button_ClickedStock(object sender, EventArgs e)
        {
            // Button deaktivieren
            IsEnabled = false;
            // neue Instanz des Lagers wenn noch keine exisitiert
            if (stock == null)
            {
                stock = new Stock();
                await Navigation.PushModalAsync(stock);
            }
            else
                await Navigation.PushModalAsync(stock);
            // Button aktivieren
            IsEnabled = true;
        }

        // Navigation zur Buchhaltung
        async private void Button_ClickedAccounting(object sender, EventArgs e)
        {
            // Button deaktivieren
            IsEnabled = false;
            // neue Instanz des Lagers wenn noch keine exisitiert
            if (accounting == null)
            {
                accounting = new Accounting();
                await Navigation.PushModalAsync(accounting);
            }
            else
                await Navigation.PushModalAsync(accounting);
            // Button aktivieren
            IsEnabled = true;
        }

        // Methode zur Übernahme des Geänderter Werte
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