using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PlayerInfo
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
}

public class PlayerInfoTable : DataTable
{
    public string infoPath = "PlayerInfo";

    public override bool SaveToJson()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.Log("Not Existed : Player");
            return false;
        }

        var playerInfo = new Hashtable
        {
            { "Position", player.transform.position },
            { "Rotation", player.transform.rotation },
            { "Scale", player.transform.localScale }
        };

        var path = Path.Combine(Application.persistentDataPath, $"{infoPath}.json");
        var json = JsonConvert.SerializeObject(playerInfo, new Vector3Converter(), new QuaternionConverter(), new ScaleConverter());

        return true;
    }

    public override bool LoadFromJson()
    {
        var path = Path.Combine(Application.persistentDataPath, $"{infoPath}.json");
        var json = File.ReadAllText(path);

        var playerInfo = JsonConvert.DeserializeObject<Hashtable>(json, new Vector3Converter(), new QuaternionConverter(), new ScaleConverter());

        var position = JsonConvert.DeserializeObject<Vector3>(playerInfo["position"].ToString(), new Vector3Converter());
        var rotation = JsonConvert.DeserializeObject<Quaternion>(playerInfo["rotation"].ToString(), new QuaternionConverter());
        var scale = JsonConvert.DeserializeObject<Vector3>(playerInfo["scale"].ToString(), new ScaleConverter());
        return true;
    }

    public override string SaveToCSV()
    {
        var path = Path.Combine(Application.persistentDataPath, $"{infoPath}.json");
        string jsonText = File.ReadAllText(path);

        StringBuilder csvData = new StringBuilder();
        var jsonFile = JsonUtility.FromJson<PlayerInfo>(jsonText);

        string csvLine = $"{jsonFile.position},{jsonFile.rotation},{jsonFile.scale}\n";

        csvData.AppendLine(csvLine);

        string csvFilePath = Path.Combine(Application.persistentDataPath, $"{infoPath}.csv");
        File.WriteAllText(csvFilePath, csvData.ToString());

        return csvFilePath;
    }

    public override void LoadFromCSV()
    {
        string csvFilePath = Path.Combine(Application.persistentDataPath, $"{infoPath}.csv");
        string[] csvLines = File.ReadAllLines(csvFilePath);

        string[] csvFields = csvLines[0].Split(',');

        PlayerInfo jsonData = new PlayerInfo()
        {
            position = CsvToVector3(csvFields[0]),
            rotation = CsvToVector3(csvFields[1]),
            scale = CsvToVector3(csvFields[2])
        };
    }

    Vector3 CsvToVector3(string csv)
    {
        string[] values = csv.Split(',');
        if (values.Length == 3)
        {
            float x = float.Parse(values[0]);
            float y = float.Parse(values[1]);
            float z = float.Parse(values[2]);
            return new Vector3(x, y, z);
        }
        else
        {
            Debug.LogError("Invalid CSV format for Vector3");
            return Vector3.zero;
        }
    }
}
