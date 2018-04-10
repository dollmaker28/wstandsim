using System;
using WStandSim.Helpers;
using Xamarin.Forms;

namespace WStandSim
{
	public partial class MainPage : ContentPage
	{
        Simulation s;
        public MainPage()
		{
			InitializeComponent();
            //this.ApplyBindings();
            s = new Simulation();
            BindingContext = s;
        }

        // Button "Neues Spiel"
        async private void Button_ClickedNewGame(object sender, EventArgs e)
        {
            // Button dekativieren
            IsEnabled = false;
            // Instanzieren der Helper-Klasse
            Helper h = new Helper();
            // Aufruf der Initializer
            h.Initializer();
            // Wechseln der Ansicht
            await Navigation.PushModalAsync(new Overview());
            // Button aktivieren
            IsEnabled = true;
        } 

        // Button "Spiel fortsetzen"
        async private void Button_ClickedContinue(object sender, EventArgs e)
        {
            // Button deaktivieren
            IsEnabled = false;
            // Wechsel der Ansicht
            await Navigation.PushModalAsync(new Overview());
            // Button aktivieren
            IsEnabled = true;
        }

        // Methode zur Übernahme des Geänderter Werte
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ButtonCont.IsVisible = s.IsGameSaved;
        }

    }
}
