using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool _isNextRoomLeft;
    public List<Transform> _powerupSpawn;
    public List<Transform> _weaponSpawn;

    public void Init()
    {
        foreach(var powerUpSpawn in _powerupSpawn)
        {
            Instantiate(PowerUpManager.Instance.GetRandomPowerUp(), powerUpSpawn);
        }

        foreach (var weaponSpawn in _weaponSpawn)
        {
            Instantiate(WeaponManager.Instance.GetRandomPowerUp(), weaponSpawn);
        }
    }

}
