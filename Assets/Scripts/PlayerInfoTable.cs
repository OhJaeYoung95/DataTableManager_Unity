using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerInfoTable : DataTable
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public string jsonPath = "PlayerInfo.json";

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

        var path = Path.Combine(Application.persistentDataPath, jsonPath);
        var json = JsonConvert.SerializeObject(playerInfo, new Vector3Converter(), new QuaternionConverter(), new ScaleConverter());

        return true;
    }

    public override bool LoadFromJson()
    {
        var path = Path.Combine(Application.persistentDataPath, jsonPath);
        var json = File.ReadAllText(path);

        var playerInfo = JsonConvert.DeserializeObject<Hashtable>(json, new Vector3Converter(), new QuaternionConverter(), new ScaleConverter());

        var position = JsonConvert.DeserializeObject<Vector3>(playerInfo["position"].ToString(), new Vector3Converter());
        var rotation = JsonConvert.DeserializeObject<Quaternion>(playerInfo["rotation"].ToString(), new QuaternionConverter());
        var scale = JsonConvert.DeserializeObject<Vector3>(playerInfo["scale"].ToString(), new ScaleConverter());

        return true;
    }

}
