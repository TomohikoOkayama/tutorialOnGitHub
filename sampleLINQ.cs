using System;
using System.Data.SqlClient;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      // 接続文字列
      string connStr = @"
        Data Source         = .\SQLEXPRESS;
        AttachDbFilename    = |DataDirectory|\NORTHWND.MDF;
        Integrated Security = True;
        User Instance       = True;";

      using (SqlConnection conn = new SqlConnection(connStr))
      {
        // 発行するSQL文
        string queryStr = @"
          SELECT OrderID, EmployeeID, OrderDate, ShipCountry
          FROM Orders
          WHERE ShipCountry = 'Norway'";

        SqlCommand command = new SqlCommand(queryStr, conn);

        conn.Open(); // コネクションのオープン
        SqlDataReader r = command.ExecuteReader(); // SQL文の実行

        // 結果を1レコードずつ取得
        while (r.Read())
        {
          Console.WriteLine("{0}, {1}, {2}, {3}",
            r["OrderID"], r["EmployeeID"],
            r["OrderDate"], r["ShipCountry"]);
        }
        r.Close();
        conn.Close();
      }
      Console.ReadLine(); // キーが押されるまで待機
    }
  }
}
