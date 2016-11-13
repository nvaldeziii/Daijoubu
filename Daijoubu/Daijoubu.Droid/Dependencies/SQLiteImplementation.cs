using Daijoubu.Dependencies;
using Daijoubu.Droid.Dependencies;
using System;
using System.IO;
using Xamarin.Forms;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteImplementation))]
namespace Daijoubu.Droid.Dependencies
{

    public class SQLiteImplementation : ISQLite
    {
        public SQLiteImplementation()
        {
        }

        #region ISQLite implementation
        public SQLite.SQLiteConnection GetJapaneseDBconnection()
        {
            return this.GetConnection("master.db3", Resource.Raw.DaijoubuJapaneseLanguage);
        }
        public SQLite.SQLiteConnection GetUserDBconnection()
        {
           return GetConnection("user.db3", Resource.Raw.userDB);
        }
        string GetPath(string DatabaseName)
        {
            var sqliteFilename = DatabaseName;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            return Path.Combine(documentsPath, sqliteFilename);
        }
        public void DeleteJapaneseDB()
        {
            DeleteDatabase("master.db3");
        }
        public void DeleteUserDB()
        {
            DeleteDatabase("user.db3");
        }
        public void DeleteDatabase(string DatabaseName)
        {
            var path = GetPath(DatabaseName);
            if (File.Exists(path)) //uncomment this to delete local db
            {
                File.Delete(path);
            }
        }

        public SQLite.SQLiteConnection GetConnection(string DatabaseName,int id)
        {
            var sqliteFilename = DatabaseName;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            //Console.WriteLine(path);
            if (!File.Exists(path) && id != -1)
            {
                var s = Forms.Context.Resources.OpenRawResource(id);  // RESOURCE NAME ###

                // create a write stream
                FileStream writeStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                // write to the stream
                ReadWriteStream(s, writeStream);
            }

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
        #endregion

        /// <summary>
        /// helper method to get the database out of /raw/ and into the user filesystem
        /// </summary>
        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}