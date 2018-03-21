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
            db.DropTables();
            db.CreateTables();

            // TODO: Tabellen mit Default-Werten befüllen

            // Jahreszeiten einfügen. Ruft Methode in UserDatabaseController auf und übergibt das Objekt
            #region Seasons
            Seasons seasons = new Seasons
            {
                Id = 1,
                SeasonsText = "Frühling",
                TempFrom = 10,
                TempTo = 24
            };
            db.AddSeason(seasons);

            seasons = new Seasons
            {
                Id = 2,
                SeasonsText = "Sommer",
                TempFrom = 20,
                TempTo = 38
            };
            db.AddSeason(seasons);

            seasons = new Seasons
            {
                Id = 3,
                SeasonsText = "Herbst",
                TempFrom = 7,
                TempTo = 24
            };
            db.AddSeason(seasons);

            seasons = new Seasons
            {
                Id = 4,
                SeasonsText = "Winter",
                TempFrom = -10,
                TempTo = 13
            };
            db.AddSeason(seasons);
            #endregion

            // Drei Zeilen für die "Buchhaltung" einfügen. Ruft Methode in UserDatabaseControler auf und übergibt das Objekt
            #region Finance
            Finance finance = new Finance
            {
                Id = 1,
                Amount = 500,
                AssetLabel = "currentBalance"
            };
            db.AddFinance(finance);

            finance = new Finance
            {
                Id = 2,
                Amount = 0,
                AssetLabel = "receiptsYesterday"
            };
            db.AddFinance(finance);

            finance = new Finance
            {
                Id = 3,
                Amount = 0,
                AssetLabel = "expendituresYesterday"
            };
            db.AddFinance(finance);
            #endregion

            // Temperaturbereiche für die jeweiligen Jahreszeiten einfügen
            #region SeasonTempRange
            SeasonTempRange seasonTempRange = new SeasonTempRange
            {
                Id = 1,
                SeasonTempRangeWeatherText = "Heute ist es bewölkt. Die Tageshöchsttemperaturen bewegen sich zwischen 12 und 14 Grad.",
                SeasonId = 1,
                TempFrom = 10,
                TempTo = 14
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 2,
                SeasonTempRangeWeatherText = "Im Laufe des Tages lockert es auf und wir bekommen maximal 19 Grad.",
                SeasonId = 1,
                TempFrom = 15,
                TempTo = 19
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 3,
                SeasonTempRangeWeatherText = "Heute lacht die Sonne den ganzen Tag und beschert uns angenehme 20 bis 24 Grad.",
                SeasonId = 1,
                TempFrom = 20,
                TempTo = 24
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 4,
                SeasonTempRangeWeatherText = "Nach einer kühlen Nacht, können wir mit Maximaltemperaturen von bis zu 26 Grad rechnen.",
                SeasonId = 2,
                TempFrom = 20,
                TempTo = 26
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 5,
                SeasonTempRangeWeatherText = "Heute wird es schwül und heiß bei 27 bis 32 Grad.",
                SeasonId = 2,
                TempFrom = 27,
                TempTo = 32
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 6,
                SeasonTempRangeWeatherText = "Glühende Hitze und Temperaturen um den Siedepunkt machen uns heute die Hölle heiß.",
                SeasonId = 2,
                TempFrom = 33,
                TempTo = 38
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 7,
                SeasonTempRangeWeatherText = "Warme Socken und ein Schal sind heute sicher nicht verkehrt bei nassen 7 bis 13 Grad.",
                SeasonId = 3,
                TempFrom = 7,
                TempTo = 13
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 8,
                SeasonTempRangeWeatherText = "Anfangs regnet es noch. Später lockert es auf und die Sonne kommt teilweise durch.",
                SeasonId = 3,
                TempFrom = 14,
                TempTo = 18
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 9,
                SeasonTempRangeWeatherText = "Der Herbst zeigt sich heute von seiner schönsten Seite und beschert und angenehme 19 bis 24 Grad.",
                SeasonId = 3,
                TempFrom = 19,
                TempTo = 24
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 10,
                SeasonTempRangeWeatherText = "Heute heißt es \"zieht euch warm an!\" bei frostigen -10 bis maximal -3 Grad.",
                SeasonId = 4,
                TempFrom = -10,
                TempTo = -3
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 11,
                SeasonTempRangeWeatherText = "Ein kalter Wintermorgen. Teilweise bricht die Sonne durch und bring uns bis zu 5 Grad.",
                SeasonId = 4,
                TempFrom = -2,
                TempTo = 5
            };
            db.AddSeasonTempRange(seasonTempRange);

            seasonTempRange = new SeasonTempRange
            {
                Id = 12,
                SeasonTempRangeWeatherText = "Man könnte heute schon fast die kurzen Hosen auspacken bei bis zu 13 Grad.",
                SeasonId = 4,
                TempFrom = 6,
                TempTo = 13
            };
            db.AddSeasonTempRange(seasonTempRange);
            #endregion

            // Artikel anlegen
            #region ItemType
            ItemType itemtype = new ItemType
            {
                Id = 1,
                ItemTypeName = "Wurst"
            };
            db.AddItemType(itemtype);

            itemtype = new ItemType
            {
                Id = 2,
                ItemTypeName = "Brot"
            };
            db.AddItemType(itemtype);

            itemtype = new ItemType
            {
                Id = 3,
                ItemTypeName = "Bier"
            };
            db.AddItemType(itemtype);

            itemtype = new ItemType
            {
                Id = 4,
                ItemTypeName = "Limonade"
            };
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
            itemSalesQuota.Id = 2; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 30; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 3; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Wurst - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 4; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 40; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 5; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 35; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 6; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 75; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Wurst Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 7; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 22; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 8; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 9; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Wurst - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 10; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 2; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 11; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 12; itemSalesQuota.ItemTypeId = 1; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #region Brot
            // Brot - Frühling
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 13; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 8; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 1;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 14; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 30; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 15; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Brot - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 16; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 40; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 17; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 35; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 18; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 75; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Brot Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 19; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 22; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 20; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 21; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Brot - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 22; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 2; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 23; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 24; itemSalesQuota.ItemTypeId = 2; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #region Bier
            // Bier - Frühling
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 25; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 1;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 26; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 27; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Bier - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 28; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 50; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 29; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 30; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 50; itemSalesQuota.SalesQuotaTo = 85; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Bier Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 31; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 32; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 33; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Bier - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 34; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 1; itemSalesQuota.SalesQuotaTo = 5; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 35; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 36; itemSalesQuota.ItemTypeId = 3; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #region Limonade
            // Limonade - Frühling
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 37; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 1;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 38; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 2;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 39; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 3;
            db.AddItemSalesQuota(itemSalesQuota);
            // Limonade - Sommer
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 40; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 30; itemSalesQuota.SalesQuotaTo = 50; itemSalesQuota.SeasonTempRangeId = 4;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 41; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 40; itemSalesQuota.SalesQuotaTo = 60; itemSalesQuota.SeasonTempRangeId = 5;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 42; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 50; itemSalesQuota.SalesQuotaTo = 85; itemSalesQuota.SeasonTempRangeId = 6;
            db.AddItemSalesQuota(itemSalesQuota);
            // Limonade Herbst
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 43; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 25; itemSalesQuota.SeasonTempRangeId = 7;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 44; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 15; itemSalesQuota.SalesQuotaTo = 35; itemSalesQuota.SeasonTempRangeId = 8;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 45; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 20; itemSalesQuota.SalesQuotaTo = 45; itemSalesQuota.SeasonTempRangeId = 9;
            db.AddItemSalesQuota(itemSalesQuota);
            // Limonade - Winter
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 46; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 1; itemSalesQuota.SalesQuotaTo = 5; itemSalesQuota.SeasonTempRangeId = 10;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 47; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 5; itemSalesQuota.SalesQuotaTo = 10; itemSalesQuota.SeasonTempRangeId = 11;
            db.AddItemSalesQuota(itemSalesQuota);
            itemSalesQuota = new ItemSalesQuota();
            itemSalesQuota.Id = 48; itemSalesQuota.ItemTypeId = 4; itemSalesQuota.SalesQuotaFrom = 10; itemSalesQuota.SalesQuotaTo = 15; itemSalesQuota.SeasonTempRangeId = 12;
            db.AddItemSalesQuota(itemSalesQuota);
            #endregion

            #endregion

            // Jahreszeit Frühling und Tag 1 einfügen
            #region SeasonDays
            SeasonDays seasonDays = new SeasonDays
            {
                Id = 1,
                CurrentSeasonID = 1,
                DaysInSeason = 1
            };
            db.AddSeasonDays(seasonDays);
            #endregion

            // Gespeichertes Spiel vermerken
            #region GameSaved
            db.SetGameIsSaved();
            #endregion

            // 1. Tag als int speichern
            #region SaveDay
            DayCount dayCount = new DayCount
            {
                Id = 1,
                ActualDay = 1
            };
            db.SaveDay(dayCount);


            #endregion

            // Preise für Artikel einfügen
            #region ItemProperties
            // Wurstpreise
            ItemProperties itemprice = new ItemProperties
            {
                Id = 1,
                ItemTypeID = 1,
                PurchasingPrice = 1.75,
                RetailPrice = 2.25,
                DaysToExpire = 15
            };
            db.AddItemPrice(itemprice);
            // Brotpreise
            itemprice = new ItemProperties
            {
                Id = 2,
                ItemTypeID = 2,
                PurchasingPrice = 0.70,
                RetailPrice = 0.90,
                DaysToExpire = 5
            };
            db.AddItemPrice(itemprice);
            // Bierpreise
            itemprice = new ItemProperties
            {
                Id = 3,
                ItemTypeID = 3,
                PurchasingPrice = 0.90,
                RetailPrice = 1.50,
                DaysToExpire = 25
            };
            db.AddItemPrice(itemprice);
            // Limonadenpreise
            itemprice = new ItemProperties
            {
                Id = 4,
                ItemTypeID = 4,
                PurchasingPrice = 0.50,
                RetailPrice = 1.15,
                DaysToExpire = 25
            };
            db.AddItemPrice(itemprice);
            #endregion

            // Wetter initial berechnen
            #region GetCurrentDayWeather
            db.CalculateCurrentDayWeather();
            #endregion
        } 
    }
}
