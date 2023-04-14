using BaseTemplate.Behaviours;
using Cinemachine;
using DG.Tweening;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>
{
    [SerializeField] Camera _mainCamera;

    public void Init()
    {
        GameManager.Instance.OnGameStateChanged += HandleStateChange;
    }



    void HandleStateChange(GameState newState)
    {

        switch (newState)
        {
            case GameState.MENU:
                HandleMenu();
                break;
            case GameState.GAME:
                HandleGame();
                break;
            case GameState.END:
                HandleEnd();
                break;
            case GameState.WAIT:
                HandleWait();
                break;
            default:
                break;
        }

    }

    void HandleMenu()
    {


    }
    void HandleGame()
    {


    }
    void HandleEnd()
    {

    }
    void HandleWait()
    {

    }

}

[Serializable]
public struct CinemachineItem
{
    public string name;
    public CinemachineVirtualCamera camera;
}