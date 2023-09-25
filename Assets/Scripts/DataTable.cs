using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class DataTable
{
    [System.Serializable]
    public enum ID
    {
        None = -1,
        PlayerInfo,
        CubeCount,
        Score

    }

    public ID id = ID.None;

    public abstract bool LoadFromJson();
    public abstract bool SaveToJson();

    public abstract string SaveToCSV();
    public abstract void LoadFromCSV();
}
