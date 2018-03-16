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
    }
}
