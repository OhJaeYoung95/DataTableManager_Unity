using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using System.IO;
using CsvHelper.Configuration;
using System.Globalization;
using SaveDataVC = SaveDataV3;

public class Example : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        //var str = DataTableMgr.GetTable<StringTable>().GetString("YOU DIE");
        //Debug.Log(str);

        //var saveData = new SaveDataV1();
        //saveData.Gold = 100;

        //SaveLoadSystem.Save(saveData, "test1.json");


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Load();
        }
    }

    public void Save()
    {
        var saveData = new SaveDataVC();
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("Cube");
        ////saveData.cubeInfos = new SaveDataV3.CubeInfo[cubes.Length];

        ////for (int i =0; i < cubes.Length;i++)
        ////{
        ////    saveData.cubeInfos[i].position = cubes[i].transform.position;
        ////    saveData.cubeInfos[i].rotation = cubes[i].transform.rotation;
        ////    saveData.cubeInfos[i].scale = cubes[i].transform.localScale;
        ////    saveData.cubeInfos[i].name = cubes[i].name;
        ////}

        foreach (var cube in cubes)
        {
            //saveData.cubeInfos.Add(new SaveDataV3.CubeInfo(cube.transform.position, cube.transform.rotation, cube.transform.localScale, cube.name));
            saveData.cubeInfos.Add(new SaveDataV3.CubeInfo()
            {
                position = cube.transform.position,
                rotation = cube.transform.rotation,
                scale = cube.transform.localScale,
                name = cube.name
            });
        }

        SaveLoadSystem.Save(saveData, "test1.json");
        Debug.Log("Completed Save");

    }

    public void Load()
    {
        var data = SaveLoadSystem.Load("test1.json") as SaveDataVC;

        foreach (var cubeInfo in data.cubeInfos)
        {
            GameObject obj = Instantiate(prefab, cubeInfo.position, cubeInfo.rotation);
            obj.transform.localScale = cubeInfo.scale;
            obj.name = cubeInfo.name;

            Debug.Log(cubeInfo.position);
            Debug.Log(cubeInfo.rotation);
            Debug.Log(cubeInfo.scale);
            Debug.Log(cubeInfo.name);
        }
    }
}
