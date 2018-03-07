using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace WStandSim.Database
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
