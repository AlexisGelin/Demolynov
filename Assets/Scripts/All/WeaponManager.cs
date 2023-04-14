using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoSingleton<WeaponManager>
{
    public GameObject[] weapons;


    public GameObject GetRandomPowerUp()
    {
        return weapons[Random.Range(0, weapons.Length)];
    }

}
