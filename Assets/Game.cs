using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Game : MonoBehaviour
{
    public List<MapObject> mapObjects;
    public GameData gameData;

    void Start()
    {
        mapObjects = new List<MapObject>();

        var foundObjects = FindObjectsOfType<MonoBehaviour>().OfType<MapObject>();

        foreach(MapObject mapObj in foundObjects)
        {
            mapObjects.Add(mapObj);
        }

        gameData = new GameData();
        gameData.mapObjectData = new List<MapObjectData>();

        foreach (MapObject mapObj in mapObjects)
        {
            gameData.mapObjectData.Add(mapObj.GetData());
        }
    }

    public void SaveData()
    {
        SaveGameData();
        print("Saved data");
    }

    public void LoadData()
    {
        gameData = null;
        gameData = LoadGameData();
        print("Loaded data");

        foreach(MapObjectData mapObjectData in gameData.mapObjectData)
        {
            GameObject mo = Instantiate(Resources.Load<GameObject>(mapObjectData.objType));
            mo.GetComponent<MapObject>().SetData(mapObjectData);
        }
    }

    public void SaveGameData()
    {
        string json = JsonUtility.ToJson(gameData, true);
        string filename = "game" + ".json";
        StreamWriter sw = File.CreateText(Path.Combine(Application.persistentDataPath, filename));
        sw.Close();
        File.WriteAllText(Path.Combine(Application.persistentDataPath, filename), json);
    }

    public GameData LoadGameData()
    {
        string filename = "game" + ".json";
        //Debug.Log(filename);
        string json = File.ReadAllText(System.IO.Path.Combine(Application.persistentDataPath, filename));
        return JsonUtility.FromJson<GameData>(json);
    }
}

[System.Serializable]
public class GameData
{
    public List<MapObjectData> mapObjectData;
}

[System.Serializable]
public class MapObjectData
{
    public string objType;
    public int[] data;
}
