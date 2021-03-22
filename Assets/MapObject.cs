using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface MapObject
{
    MapObjectData GetData();

    void SetData(MapObjectData data);
}
