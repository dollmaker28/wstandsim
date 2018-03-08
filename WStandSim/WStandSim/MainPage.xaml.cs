﻿using System;
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
            UserDatabaseController db = new UserDatabaseController();
            DisplayMessage();
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
            await Navigation.PushAsync(new Overview());
        }

        
    }
}
