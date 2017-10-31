using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      // NorthWindDataContextクラスはVS 2008により自動生成
      NorthWindDataContext dc = new NorthWindDataContext();

      // LINQによる問い合わせ
      IEnumerable<Orders> records =
            from n in dc.Orders
            where n.ShipCountry == "Norway"
            select n;

      // 問い合わせ結果の表示
      foreach (Orders r in records)
      {
        Console.WriteLine("{0}, {1}, {2}, {3}",
          r.OrderID, r.EmployeeID, r.OrderDate, r.ShipCountry);
      }
      Console.ReadLine();
    }
  }
}
