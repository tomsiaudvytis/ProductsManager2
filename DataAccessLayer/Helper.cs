namespace DataAccessLayer
{
    using System;
    using System.Data.SQLite;
    using System.IO;

    public static class Helper
    {
        public static string DbConnection()
        {
            string sqliteFile = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\ProductsManagerDB.db";

            if (File.Exists(sqliteFile))
            {
                return $@"Data Source={sqliteFile}";
            }
            else
            {
                CreateDatabase(sqliteFile);
                return $@"Data Source={sqliteFile}";
            }
        }

        //Create DB with 3 tables in it.
        public static void CreateDatabase(string sqliteFile)
        {
            if (File.Exists(sqliteFile))
            {
                DeleteDatabase(sqliteFile);
            }

            SQLiteConnection.CreateFile(sqliteFile);

            using (var sqlConn = new SQLiteConnection("Data Source=" + sqliteFile))
            {
                sqlConn.Open();
                string query = $@"CREATE TABLE IF NOT EXISTS Dates ( SF_Number TEXT (100) CONSTRAINT PK_Dates PRIMARY KEY NOT NULL, Date TEXT (50)  NOT NULL );";
                query += $@"CREATE TABLE IF NOT EXISTS ProductItem (Product_Item_Id TEXT (100) CONSTRAINT PK_ProductItem PRIMARY KEY NOT NULL,Product_Name TEXT (100) NOT NULL, Unit TEXT (15) NOT NULL );";
                query += $@"CREATE TABLE IF NOT EXISTS Products ( Product_Item_Id TEXT (100) NOT NULL CONSTRAINT FK_PRODUCTS_ITEM_ID REFERENCES ProductItem (Product_Item_Id), SF_Number TEXT(100) CONSTRAINT FR_Dates_SFNUMBER REFERENCES Dates (SF_Number) NOT NULL,Price DECIMAL (15) NOT NULL, Quantity TEXT (100) NOT NULL );";
                using (var command = new SQLiteCommand(query, sqlConn))
                {
                    command.ExecuteNonQuery();
                    sqlConn.Dispose();
                }
            };

            //Sql lite does not release db properly..
            GC.Collect();
        }

        public static void DeleteDatabase(string sqliteFile)
        {
            if (File.Exists(sqliteFile))
            {
                File.Delete(sqliteFile);
            }
        }
    }
}