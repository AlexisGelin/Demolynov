using BaseTemplate.Behaviours;
using UnityEngine;

public class PartyManager : MonoSingleton<PartyManager>
{
    [SerializeField] Transform _p1Spawn, _p2Spawn;
    [SerializeField] GameObject _P1, _P2;

    public void Init()
    {
        _P1.transform.position = _p1Spawn.position;
        _P2.transform.position = _p2Spawn.position;
    }
}
