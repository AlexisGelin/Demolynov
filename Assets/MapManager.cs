using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField] Room _prefabRoom;
    [SerializeField] Room _lastRoom, _startRoom;


    [SerializeField] List<Room> _rightRoom, _leftBoom;

    public void Init()
    {
        _lastRoom = _startRoom;
        GenerateRoom();
    }

    public void GenerateRoom()
    {
        
    }
}
