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

        // Berechnung der Jahreszeit und des aktuellen Tages
        public void SimulateNewDayAndSeason()
        {
            db.SetCurrentDayAndSeasonNewDay();
        }
    }
}
