using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class QueryDuplicateFileNames改
{
  static void Main(string[] args)
  {
    // 検索開始ディレクトリ
    string startFolder =
        @"d:\program files\Microsoft Visual Studio 9.0\";

    int charsToSkip = startFolder.Length;

    // ファイルを列挙し、それらのFileInfoオブジェクトを取得
    IEnumerable<FileInfo> fileList =
        Directory.GetFiles(startFolder, "*.*",
        SearchOption.AllDirectories).Select(x => new FileInfo(x));

    // LINQのクエリ
    var queryDupNames =
      from file in fileList
      group file.FullName.Substring(charsToSkip)
                              by file.Name into fileGroup
      where fileGroup.Count() > 1
      select fileGroup;

    foreach (var filegroup in queryDupNames)
    {
      foreach (var fileName in filegroup)
      {
        Console.WriteLine(fileName);
      }
      Console.WriteLine();
    }
  }
}