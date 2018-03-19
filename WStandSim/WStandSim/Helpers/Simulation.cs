using System;
using System.Collections.Generic;
using System.Text;
using WStandSim.Database;
using System.ComponentModel;

namespace WStandSim.Helpers
{
    // Klasse für die Simulation des gesamten Tages
    class Simulation : DBBase
    {
        // Instanzierung des DB-Controllers
        UserDatabaseController db = new UserDatabaseController();

        // Berechnung der Jahreszeit für den kommenden Tag
        public void SimulateNewDayAndSeason()
        {
            db.SetCurrentDayAndSeasonNewDay();
            NotifyPropertyChanged("ReturnWeather");
        }

        // Wetter neu berechnen lassen
        public void CalculateNewWeather()
        {
            db.CalculateCurrentDayWeather();
            NotifyPropertyChanged("ReturnWeather");
        }

        // Ausgabe der Wettervorhersage
        public string ReturnWeather { get { return db.WeatherForecast(); } }

        // Properties für die Zähler auf der Verkaufsseite
        #region PropsArtikel
        // Variablen
        public int sausages, bread, beer, lemonades;
        // Properties
        public int Sausages
        { get { return sausages; } set { sausages = value; NotifyPropertyChanged(); } }
        public int Bread
        { get { return bread; } set { bread = value; NotifyPropertyChanged(); } }
        public int Beer
        { get { return beer; } set { beer = value; NotifyPropertyChanged(); } }
        public int Lemonades
        { get { return lemonades; } set { lemonades = value; NotifyPropertyChanged(); } }
        #endregion

        // Methode zum Erhöhen und Reduzieren der Artikel auf der Verkaufsseite
        // Wurst
        public void RaiseSausages()
        {
            int a = sausages;
            Sausages = a + 1;
        }
        public void LowerSausages()
        {
            int a = sausages;
            if (a == 0) { } else Sausages = a - 1;
        }
        // Brot
        public void RaiseBread()
        {
            int a = bread;
            Bread = a + 1;
        }
        public void LowerBread()
        {
            int a = bread;
            if (a == 0) { } else Bread = a - 1;
        }
        // Bier
        public void RaiseBeer()
        {
            int a = beer;
            Beer = a + 1;
        }
        public void LowerBeer()
        {
            int a = beer;
            if (a == 0) { } else Beer = a - 1;
        }
        // Limonade
        public void RaiseLemonades()
        {
            int a = lemonades;
            Lemonades = a + 1;
        }
        public void Loweremonades()
        {
            int a = lemonades;
            if (a == 0) { } else Lemonades = a - 1;
        }
    }
}
