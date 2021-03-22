using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Chest : MonoBehaviour, MapObject
{
    public int[] inventory;
    public int inventorySize;
    public float durability;

    public MapObjectData GetData()
    {
        MapObjectData data = new MapObjectData();
        
        data.objType = GetType().ToString();

        inventorySize = inventory.Length;

        data.data = new int[inventorySize + 2];

        data.data[0] = inventorySize;

        for(int i = 0; i < inventorySize; i++)
        {
            data.data[i + 1] = inventory[i];
        }

        data.data[inventorySize + 1] = Mathf.RoundToInt(durability * 1000);

        return data;
    }

    public void SetData(MapObjectData data)
    {
        inventorySize = data.data[0];
        inventory = new int[inventorySize];

        if (inventorySize > 0)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                inventory[i] = data.data[i + 1];
            }
        }

        durability = (float)(data.data[inventorySize + 1] * 0.001);
    }
}
