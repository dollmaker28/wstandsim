using System;
using System.Collections.Generic;
using System.Text;
using WStandSim.Database;
using WStandSim.Models;

namespace WStandSim
{
    public class Helper
    {
        // Wenn ein neues Spiel gestartet wird, soll die Db angelegt werden,
        // die Tabellen befüllt werden und der Startbetrag auf 500 gesetzt werden.
        // Weiter soll die Berechnung des Wetters durchgeführt werden.
        public void Initializer()
        {
            // Instanzieren der Datenbank-Klasse
            UserDatabaseController db = new UserDatabaseController();
            db.CreateTables();
        }
    }
}
