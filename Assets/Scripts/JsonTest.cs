using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class MyClass
{
    public string myClassName;
}
[System.Serializable]
public class MyClass2 : MyClass
{
    public string myClassName2 = "2";
}


//[System.Serializable]
//public class PlayerInfo
//{
//    public string name;
//    public int lives;
//    public float health;

//    public MyClass myclass;

//    public int[] array;

//    public Hashtable ht;

//    public Vector3 position;
//    public Vector3 rotation;

//    //public string ToJson()
//    //{
//    //    //return JsonUtility.ToJson(this, true);
//    //    return JsonConvert.SerializeObject(this);
//    //}

//    //public static PlayerInfo CreateFromJSON(string jsonString)
//    //{
//    //    //return JsonUtility.FromJson<PlayerInfo>(jsonString);
//    //    return JsonConvert.DeserializeObject<PlayerInfo>(jsonString);
//    //}

//    // Given JSON input:
//    // {"name":"Dr Charles","lives":3,"health":0.8}
//    // this example will return a PlayerInfo object with
//    // name == "Dr Charles", lives == 3, and health == 0.8f.
//}

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //string jsonString = @"{""name"":""Dr Charles"",""lives"":3,""health"":0.8, ""array"" : [1, 2, 3]}";
        //var info = PlayerInfo.CreateFromJSON(jsonString);
        //var info = new PlayerInfo();

        //Debug.Log(info.name);
        //Debug.Log(info.lives);
        //Debug.Log(info.health);

        //foreach (var item in info.array)
        //{
        //    Debug.Log(item);
        //}

        //info.name = "Dr Charles Jr!!!";
        //info.lives = 10;
        //info.health = 10.8f;
        //info.myclass = new MyClass2();
        //info.myclass.myClassName = "myClassName";

        //info.array = new int[3] { 10, 20, 30 };
        //info.ht = new Hashtable();
        //info.ht.Add("Key1", "Value1");

        //info.position = new Vector3(2, 3, 4);
        //info.rotation = new Vector3(2, 3, 4);


        //var json = JsonConvert.SerializeObject(info, new Vector3Converter());

        //Debug.Log(json);

        //jsonString = info.ToJson();
        //Debug.Log(jsonString);
    }
}
