using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UIElements;
using System.IO;

public class DataTableManager : MonoBehaviour
{
    public static DataTableManager Instance { get; private set; }

    public GameObject player;
    public GameObject[] cubes;
    public int score;

    private Dictionary<DataTable1.ID, DataTable1> tables;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        //tables.Add(DataTable.ID.PlayerInfo, new PlayerInfoTable());
        //tables.Add(DataTable.ID.CubeCount, new DataTable());
        //tables.Add(DataTable.ID.Score, new DataTable());

    }

    public void LoadAllFromJson()
    {
        tables[DataTable1.ID.PlayerInfo].LoadFromJson();
    }

    public void LoadAllFromCSV()
    {
        tables[DataTable1.ID.PlayerInfo].LoadFromCSV();
    }

    public void Release(DataTable1.ID id)
    {
        tables.Remove(id);
    }

    public void ReleaseAll()
    {
        tables.Clear();
    }
}
