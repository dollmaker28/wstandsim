using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WStandSim.Models;
using Xamarin.Forms;

namespace WStandSim.Database
{
    public class UserDatabaseController
    {

        static object locker = new object();

        SQLiteConnection database;

        // DB-Verbindung aufbauen
        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
        }

        // Erstellen der Tabellen
        public void CreateTables()
        {
            database.CreateTable<StoredItems>();
            database.CreateTable<ItemType>();
            database.CreateTable<ItemSalesQuota>();
            database.CreateTable<Finance>();
            database.CreateTable<Weather>();
            database.CreateTable<Seasons>();
            database.CreateTable<SeasonTempRange>();
            database.CreateTable<GameSaved>();
        }

        // Finanzen einfügen
        public void AddFinance(Finance finance)
        {
            database.Insert(finance);
            database.Commit();
        }

        // Jahreszeiten einfügen
        public void AddSeason(Seasons season)
        {
            database.Insert(season);
            database.Commit();
        }

        // Jahreszeit-Temperaturbereiche einfügen
        public void AddSeasonTempRange(SeasonTempRange seasonTempRange)
        {
            database.Insert(seasonTempRange);
            database.Commit();
        }
    }
}
