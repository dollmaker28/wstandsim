using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WStandSim.Database
{
    public class UserDatabaseController
    {

        static object locker = new object();

        SQLiteConnection database;

        public UserDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<StoredItems>();
            database.CreateTable<ItemType>();
            database.CreateTable<ItemSalesQuota>();
            database.CreateTable<Finance>();
            database.CreateTable<Weather>();
            database.CreateTable<Seasons>();
            database.CreateTable<SeasonTempRange>();
        }
    }
}
