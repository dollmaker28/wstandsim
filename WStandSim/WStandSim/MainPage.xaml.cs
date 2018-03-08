using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WStandSim.Database;
using Xamarin.Forms;

namespace WStandSim
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        // Button "Neues Spiel"
        async private void Button_ClickedNewGame(object sender, EventArgs e)
        {
            // Instanzieren der Helper-Klasse
            Helper h = new Helper();
            // Aufruf der Initializer
            h.Initializer();

            // Hilfsmethode um zu sehen, ob der Button was macht
            DisplayMessage();
            // Wechseln der Ansicht
            await Navigation.PushAsync(new Overview());
        }

        // Hilfsklasse für die Überprüfung ob der Button was macht. Kann wieder gelöscht werden.
        // Aufruf in Button_ClickedNewGame
        private void DisplayMessage()
        {
            DisplayAlert("Achtung!", "Die Datenbank wurde angelegt!", "Weiter...");
        }

        // Button "Spiel fortsetzen"
        async private void Button_ClickedContinue(object sender, EventArgs e)
        {
            // Wechsel der Ansicht
            await Navigation.PushAsync(new Overview());
        }

        
    }
}
