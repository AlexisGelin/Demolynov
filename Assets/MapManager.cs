using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoSingleton<MapManager>
{
    [SerializeField] Room _lastRoom, _startRoom;
    [SerializeField] List<Room> _rightRoom, _leftRoom;

    public void Init()
    {
        _lastRoom = _startRoom;
        _lastRoom.Init();
        GenerateRoom();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            GenerateRoom();
        }
    }

    public void GenerateRoom()
    {

        if (_lastRoom._isNextRoomLeft)
        {
            _lastRoom = Instantiate(_leftRoom[Random.Range(0, _leftRoom.Count)], _lastRoom.transform.position + new Vector3(0, 0, 30), Quaternion.identity);
        }
        else
        {
            _lastRoom = Instantiate(_rightRoom[Random.Range(0, _rightRoom.Count)], _lastRoom.transform.position + new Vector3(30, 0, 0), Quaternion.identity);
        }

        _lastRoom.Init();
    }
}
