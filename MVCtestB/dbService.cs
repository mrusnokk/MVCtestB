using Dapper;
using Microsoft.Data.Sqlite;
using MVCtestB.Models;
using System.Data.Common;

namespace MVCtestB
{
    public class dbService
    {
        public string database = "Data Source=jj.db";

        public void Initialize()
        {
            using (SqliteConnection con = new SqliteConnection(database))
            {
                con.Open();
                string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS Transakce (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Jmeno NVARCHAR(100) NOT NULL,
                        Castka FLOAT NOT NULL,
                        penize NVARCHAR(10) NOT NULL,
                        CisloUctu NVARCHAR(50) NOT NULL
                     )";
                con.Execute(createTableSql);
            }
        }

        public dbService() {
            Initialize();
        }

        public void Insert(MainFormModel m) {
            using (SqliteConnection con = new SqliteConnection(database)) {
                con.Open();
                string sql = @"INSERT INTO Transakce(Jmeno,Castka,penize,CisloUctu) VALUES(@Jmeno,@Castka,@penize,@CisloUctu)";
                con.Execute(sql, new { 
                    m.Jmeno,
                    m.Castka,
                    m.penize,
                    m.CisloUctu
                });
            }
        }

        public List<MainFormModel> Get()
        {
            using (SqliteConnection con = new SqliteConnection(database))
            {
                con.Open();
                string sql = @"SELECT * FROM Transakce";
                return con.Query<MainFormModel>(sql).ToList();
                
            }
        }


    }
}
