using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoSingleton<PowerUpManager>
{
    public List<PowerUp> powerUpList;

    public PowerUp GetRandomPowerUp()
    {
        return powerUpList[Random.Range(0, powerUpList.Count)];
    }
}
