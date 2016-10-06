using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Daijoubu.Dependencies;
using SQLite;
using System.Runtime.CompilerServices;
using Daijoubu.Droid.Dependencies;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteImplementation))]
namespace Daijoubu.Droid.Dependencies
{
    
    public class SQLiteImplementation : ISQLite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "DaijoubuJapaneseLanguage.sqlite3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLite.SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}