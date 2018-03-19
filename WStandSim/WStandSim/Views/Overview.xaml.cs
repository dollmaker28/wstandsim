﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WStandSim.Database;
using WStandSim.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WStandSim
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Overview : ContentPage
    {

        Simulation s;
        UserDatabaseController u;
        public Overview()
        {
            InitializeComponent();
            s = new Simulation();
            //u = new UserDatabaseController();
            s.ReturnWeather.ToString();
            BindingContext = s;
            //u.SelectCurrentBalance();
        }

        private void Button_ClickedContinue(object sender, EventArgs e)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // TODO:
            // Hier muss die Kalkulation für die Verkäufe rein. Diese müssen vor der Neuberechnung des Wetters laufen!
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // TODO:
            // Hier müssen die abgelaufenen Waren aus der Datenbank entfernt und der Verlust vermerkt werden.
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Instanzierung der Klasse Simulation
            //Simulation s = new Simulation();

            // und Wetter für den kommenden Tag neu berechnen.
            // BindingContext
            //BindingContext = s;
            // Tag und ev. Jahreszeit um 1 nach vorne setzen
            s.SimulateNewDayAndSeason();
            s.CalculateNewWeather();
        }


        async private void Button_ClickedStock(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Stock());
        }
    }
}