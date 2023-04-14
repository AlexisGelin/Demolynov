using BaseTemplate.Behaviours;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MENU, GAME, END, WAIT }

public class GameManager : MonoSingleton<GameManager>
{
    public event Action<GameState> OnGameStateChanged;

    public PlayerController Player1, Player2;

    GameState _gameState;
    public GameState GameState { get => _gameState; }

    bool _isPauseActive;

    private void Awake()
    {
        Time.timeScale = 1;

        ObjectPooler.Instance.Init();

        UIManager.Instance.Init();

        MapManager.Instance.Init();

        CameraManager.Instance.Init();


        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameState == GameState.GAME) SwitchPause();
        }
    }

    public void UpdateGameState(GameState newState)
    {
        _gameState = newState;

        switch (_gameState)
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
        OnGameStateChanged?.Invoke(_gameState);
    }

    void HandleMenu()
    {

    }

    void HandleGame()
    {
        PartyManager.Instance.Init();
    }

    public void SwitchPause()
    {
        if (_isPauseActive)
        {
            _isPauseActive = false;
            HandlePause();
            UIManager.Instance.HandleClosePause();
        }
        else
        {
            HandleExitPause();
            _isPauseActive = true;
            UIManager.Instance.HandleOpenPause();
        }
    }

    void HandlePause()
    {
        Time.timeScale = 0;
    }

    void HandleExitPause()
    {
        Time.timeScale = 1;
    }

    void HandleEnd()
    {
    }

    void HandleWait()
    {

    }

    public void UpdateStateToMenu() => UpdateGameState(GameState.MENU);
    public void UpdateStateToGame() => UpdateGameState(GameState.GAME);
    public void UpdateStateToEnd() => UpdateGameState(GameState.END);

    public void ReloadScene()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetGame()
    {
        UpdateGameState(GameState.MENU);
    }

    public void QuitApp() => Application.Quit();


}