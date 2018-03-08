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

        // TODO:
        // Weiter soll die Berechnung des Wetters durchgeführt werden.
        public void Initializer()
        {
            // Instanzieren der Datenbank-Klasse
            UserDatabaseController db = new UserDatabaseController();
            db.CreateTables();

            // TODO: Tabellen mit Default-Werten befüllen

            // Jahreszeiten einfügen. Ruft Methode in UserDatabaseController auf und übergibt das Objekt
            #region Seasons
            Seasons seasons = new Seasons();
            seasons.Id = 1; seasons.SeasonsText = "Frühling"; seasons.TempFrom = 10; seasons.TempTo = 24;
            db.AddSeason(seasons);

            seasons = new Seasons();
            seasons.Id = 2; seasons.SeasonsText = "Sommer"; seasons.TempFrom = 20; seasons.TempTo = 38;
            db.AddSeason(seasons);

            seasons = new Seasons();
            seasons.Id = 3; seasons.SeasonsText = "Herbst"; seasons.TempFrom = 7; seasons.TempTo = 24;
            db.AddSeason(seasons);

            seasons = new Seasons();
            seasons.Id = 4; seasons.SeasonsText = "Winter"; seasons.TempFrom = -10; seasons.TempTo = 13;
            db.AddSeason(seasons);
            #endregion

            // Drei Zeilen für die "Buchhaltung" einfügen. Ruft Methode in UserDatabaseControler auf und übergibt das Objekt
            #region Finance
            Finance finance = new Finance();
            finance.Id = 1; finance.Amount = 500; finance.AssetLabel = "currentBalance";
            db.AddFinance(finance);

            finance = new Finance();
            finance.Id = 2; finance.Amount = 0; finance.AssetLabel = "receiptsYesterday";
            db.AddFinance(finance);

            finance = new Finance();
            finance.Id = 3; finance.Amount = 0; finance.AssetLabel = "expendituresYesterday";
            db.AddFinance(finance);
            #endregion

            // Temperaturbereiche für die jeweiligen Jahreszeiten einfügen
            #region SeasonTempRange
            SeasonTempRange seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 1; seasonTempRange.SeasonTempRangeWeatherText = "FrühlingA"; seasonTempRange.SeasonId = 1; seasonTempRange.TempFrom = 10; seasonTempRange.TempTo = 14;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 2; seasonTempRange.SeasonTempRangeWeatherText = "FrühlingB"; seasonTempRange.SeasonId = 1; seasonTempRange.TempFrom = 15; seasonTempRange.TempTo = 19;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 3; seasonTempRange.SeasonTempRangeWeatherText = "FrühlingC"; seasonTempRange.SeasonId = 1; seasonTempRange.TempFrom = 20; seasonTempRange.TempTo = 24;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 4; seasonTempRange.SeasonTempRangeWeatherText = "SommerA"; seasonTempRange.SeasonId = 2; seasonTempRange.TempFrom = 20; seasonTempRange.TempTo = 26;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 5; seasonTempRange.SeasonTempRangeWeatherText = "SommerB"; seasonTempRange.SeasonId = 2; seasonTempRange.TempFrom = 27; seasonTempRange.TempTo = 32;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 6; seasonTempRange.SeasonTempRangeWeatherText = "SommerC"; seasonTempRange.SeasonId = 2; seasonTempRange.TempFrom = 33; seasonTempRange.TempTo = 38;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 7; seasonTempRange.SeasonTempRangeWeatherText = "HerbstA"; seasonTempRange.SeasonId = 3; seasonTempRange.TempFrom = 7; seasonTempRange.TempTo = 13;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 8; seasonTempRange.SeasonTempRangeWeatherText = "HerbstB"; seasonTempRange.SeasonId = 3; seasonTempRange.TempFrom = 14; seasonTempRange.TempTo = 18;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 9; seasonTempRange.SeasonTempRangeWeatherText = "HerbstC"; seasonTempRange.SeasonId = 3; seasonTempRange.TempFrom = 19; seasonTempRange.TempTo = 24;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 10; seasonTempRange.SeasonTempRangeWeatherText = "WinterA"; seasonTempRange.SeasonId = 4; seasonTempRange.TempFrom = -10; seasonTempRange.TempTo = -3;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 11; seasonTempRange.SeasonTempRangeWeatherText = "WinterB"; seasonTempRange.SeasonId = 4; seasonTempRange.TempFrom = -2; seasonTempRange.TempTo = 5;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 12; seasonTempRange.SeasonTempRangeWeatherText = "WinterC"; seasonTempRange.SeasonId = 4; seasonTempRange.TempFrom = 6; seasonTempRange.TempTo = 13;
            db.AddSeasonTempRange(seasonTempRange);
            #endregion




        }
    }
}
