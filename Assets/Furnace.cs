using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Furnace : MonoBehaviour, MapObject
{
    public int fuelAmount;
    public bool isActive;

    public MapObjectData GetData()
    {
        MapObjectData data = new MapObjectData();

        data.data = new int[2];

        data.objType = GetType().ToString();

        data.data[0] = fuelAmount;
        data.data[1] = isActive ? 1 : 0;

        return data;
    }

    public void SetData(MapObjectData data)
    {
        fuelAmount = data.data[0];
        isActive = System.Convert.ToBoolean(data.data[1]);
    }
}
