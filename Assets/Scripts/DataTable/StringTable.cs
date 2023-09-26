using CsvHelper.Configuration;
using CsvHelper;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class StringTable : DataTable
{
    public class Data
    {
        public string ID { get; set; }
        public string STRING { get; set; }
    }

    private Dictionary<string, string> dic = new Dictionary<string, string>();

    public StringTable()
    {
        //path = Path.Combine(Application.dataPath, "Tables/StringTable.csv");

        path = "Tables/StringTable";
        Load();
    }

    public override void Load()
    {
        //string csvFileText =File.ReadAllText(path);
        //TextReader reader = new StringReader(csvFileText);

        var csvStr = Resources.Load<TextAsset>(path);
        TextReader reader = new StringReader(csvStr.text);
        var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        var records = csv.GetRecords<Data>();

        foreach (var record in records)
        {
            dic.Add(record.ID, record.STRING);
        }

    }

    public string GetString(string id)
    {
        if(!dic.ContainsKey(id))
        {
            return string.Empty;
        }

        return dic[id];
    }

}
