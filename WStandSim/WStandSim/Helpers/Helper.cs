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
            seasonTempRange.Id = 1; seasonTempRange.SeasonTempRangeWeatherText = "Heute ist es bewölkt. Die Tageshöchsttemperaturen bewegen sich zwischen 12 und 14 Grad."; seasonTempRange.SeasonId = 1; seasonTempRange.TempFrom = 10; seasonTempRange.TempTo = 14;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 2; seasonTempRange.SeasonTempRangeWeatherText = "Im Laufe des Tages lockert es auf und wir bekommen maximal 19 Grad."; seasonTempRange.SeasonId = 1; seasonTempRange.TempFrom = 15; seasonTempRange.TempTo = 19;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 3; seasonTempRange.SeasonTempRangeWeatherText = "Heute lacht die Sonne den ganzen Tag und beschert uns angenehme 20 bis 24 Grad."; seasonTempRange.SeasonId = 1; seasonTempRange.TempFrom = 20; seasonTempRange.TempTo = 24;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 4; seasonTempRange.SeasonTempRangeWeatherText = "Nach einer kühlen Nacht, können wir mit Maximaltemperaturen von bis zu 26 Grad rechnen."; seasonTempRange.SeasonId = 2; seasonTempRange.TempFrom = 20; seasonTempRange.TempTo = 26;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 5; seasonTempRange.SeasonTempRangeWeatherText = "Heute wird es schwül und heiß bei 27 bis 32 Grad."; seasonTempRange.SeasonId = 2; seasonTempRange.TempFrom = 27; seasonTempRange.TempTo = 32;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 6; seasonTempRange.SeasonTempRangeWeatherText = "Glühende Hitze und Temperaturen um den Siedepunkt machen uns heute die Hölle heiß."; seasonTempRange.SeasonId = 2; seasonTempRange.TempFrom = 33; seasonTempRange.TempTo = 38;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 7; seasonTempRange.SeasonTempRangeWeatherText = "Warme Socken und ein Schal sind heute sicher nicht verkehrt bei nassen 7 bis 13 Grad."; seasonTempRange.SeasonId = 3; seasonTempRange.TempFrom = 7; seasonTempRange.TempTo = 13;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 8; seasonTempRange.SeasonTempRangeWeatherText = "Anfangs regnet es noch. Später lockert es auf und die Sonne kommt teilweise durch."; seasonTempRange.SeasonId = 3; seasonTempRange.TempFrom = 14; seasonTempRange.TempTo = 18;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 9; seasonTempRange.SeasonTempRangeWeatherText = "Der Herbst zeigt sich heute von seiner schönsten Seite und beschert und angenehme 19 bis 24 Grad."; seasonTempRange.SeasonId = 3; seasonTempRange.TempFrom = 19; seasonTempRange.TempTo = 24;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 10; seasonTempRange.SeasonTempRangeWeatherText = "Heute heißt es \"zieht euch warm an!\" bei frostigen -10 bis maximal -3 Grad."; seasonTempRange.SeasonId = 4; seasonTempRange.TempFrom = -10; seasonTempRange.TempTo = -3;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 11; seasonTempRange.SeasonTempRangeWeatherText = "Ein kalter Wintermorgen. Teilweise bricht die Sonne durch und bring uns bis zu 5 Grad."; seasonTempRange.SeasonId = 4; seasonTempRange.TempFrom = -2; seasonTempRange.TempTo = 5;
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange();
            seasonTempRange.Id = 12; seasonTempRange.SeasonTempRangeWeatherText = "Man könnte heute sc hon fast die kurzen Hosen auspacken bei bis zu 13 Grad."; seasonTempRange.SeasonId = 4; seasonTempRange.TempFrom = 6; seasonTempRange.TempTo = 13;
            db.AddSeasonTempRange(seasonTempRange);
            #endregion

            // Artikel anlegen
            #region ItemType
            ItemType itemtype = new ItemType();
            itemtype.Id = 1; itemtype.ItemTypeName = "Wurst";
            db.AddItemType(itemtype);

            itemtype = new ItemType();
            itemtype.Id = 2; itemtype.ItemTypeName = "Brot";
            db.AddItemType(itemtype);

            itemtype = new ItemType();
            itemtype.Id = 3; itemtype.ItemTypeName = "Bier";
            db.AddItemType(itemtype);

            itemtype = new ItemType();
            itemtype.Id = 4; itemtype.ItemTypeName = "Limonade";
            db.AddItemType(itemtype);
            #endregion

            // Verkaufsquoten anlegen
            #region ItemSalesQuota
            #region Wurst
            // Wurst - Frühling
            ItemSalesQuota itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 8; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 1;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 30; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Wurst - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 40; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 35; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 75; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Wurst Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 22; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Wurst - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 2; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #region Brot
            // Brot - Frühling
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 8; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 1;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 30; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Brot - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 40; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 35; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 75; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Brot Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 22; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Brot - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 2; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #region Bier
            // Bier - Frühling
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 1;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Bier - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 50; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 50; itemSalesQuota.SalesQuotaTo = 85; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Bier Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Bier - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 1; itemSalesQuota.SalesQuotaTo = 5; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #region Limonade
            // Limonade - Frühling
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 1;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Limonade - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 50; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 50; itemSalesQuota.SalesQuotaTo = 85; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Limonade Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Limonade - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 1; itemSalesQuota.SalesQuotaTo = 5; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 1; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #endregion


        }
    }
}
