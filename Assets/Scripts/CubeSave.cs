using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class CubeSave : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Clear();
        }
    }
    public void Save()
    {
        var cubeList = new List<Hashtable>();
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            cubeList.Add(new Hashtable
            {
                { "position", cube.transform.position },
                { "rotation", cube.transform.rotation },
                { "scale", cube.transform.localScale }
            });
        }


        var path = Path.Combine(Application.persistentDataPath, "cubes.json");
        //Debug.Log(path);

        var json = JsonConvert.SerializeObject(cubeList, new Vector3Converter(), new QuaternionConverter(), new ScaleConverter());
        //Debug.Log(json);

        File.WriteAllText(path, json);
    }

    public void Clear()
    {
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            Destroy(cube);
        }
    }

    public void Load()
    {
        var path = Path.Combine(Application.persistentDataPath, "cubes.json");

        var json = File.ReadAllText(path);

        var cubeList = JsonConvert.DeserializeObject<List<Hashtable>>(json, new Vector3Converter(), new QuaternionConverter(), new ScaleConverter());

        foreach (var cube in cubeList)
        {
            var position = JsonConvert.DeserializeObject<Vector3>(cube["position"].ToString(), new Vector3Converter());
            var rotation = JsonConvert.DeserializeObject<Quaternion>(cube["rotation"].ToString(), new QuaternionConverter());
            var scale = JsonConvert.DeserializeObject<Vector3>(cube["scale"].ToString(), new ScaleConverter());
            var gameObj = Instantiate(prefab, position, rotation);
            gameObj.transform.localScale = scale;
        }
    }
}
