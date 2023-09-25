using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UIElements;
using System.IO;

public class DataTableManager : MonoBehaviour
{
    Dictionary<DataTable.ID, DataTable> tables;

    private void Awake()
    {
        //tables.Add(DataTable.ID.PlayerInfo, new DataTable());
        //tables.Add(DataTable.ID.CubeCount, new DataTable());
        //tables.Add(DataTable.ID.Score, new DataTable());

    }

    public void LoadAll()
    {
        tables[DataTable.ID.PlayerInfo].LoadFromJson();
    }

    public void Release(DataTable.ID id)
    {
        tables.Remove(id);
    }

    public void ReleaseAll()
    {
        tables.Clear();
    }
}
