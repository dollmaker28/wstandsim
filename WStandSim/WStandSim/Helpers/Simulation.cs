using System;
using System.Collections.Generic;
using System.Text;
using WStandSim.Database;

namespace WStandSim.Helpers
{
    // Klasse für die Simulation des gesamten Tages
    class Simulation
    {
        // Instanzierung des DB-Controllers
        UserDatabaseController db = new UserDatabaseController();

        // Berechnung der Jahreszeit für den kommenden Tag
        public void SimulateNewDayAndSeason()
        {
            db.SetCurrentDayAndSeasonNewDay();
        }

        public string Result
        {
            get
            {
                return CalculateWeather().ToString();
            }
        }
        public string CalculateWeather()
        {
            string result = db.GetCurrentDayWeather();
            return result;
        }
    }
}
