using BaseTemplate.Behaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] MenuPanel _menuPanel;
    [SerializeField] GamePanel _gamePanel;
    [SerializeField] EndGamePanel _endGamePanel;
    [SerializeField] PausePanel _pausePanel;
    [SerializeField] SettingPanel _settingPanel;
    [SerializeField] BlankPanel _blankPanel;

    Panel _currentPanel;

    public MenuPanel MenuPanel { get => _menuPanel; }
    public GamePanel GamePanel { get => _gamePanel; }

    public void Init()
    {
        GameManager.Instance.OnGameStateChanged += HandleStateChange;

        _menuPanel.Init();
        _gamePanel.Init();
        _endGamePanel.Init();
        _pausePanel.Init();
        _settingPanel.Init();
    }

    void ChangePanel(Panel newPanel, bool _isAddingCanvas = false)
    {
        if (newPanel == _currentPanel) return;

        if (_currentPanel != null)
        {
            if (_isAddingCanvas == false)
            {
                _currentPanel.ClosePanel();
                _currentPanel.gameObject.SetActive(false);
            }
        }

        _currentPanel = newPanel;

        _currentPanel.gameObject.SetActive(true);
        _currentPanel.OpenPanel();
    }

    void ClosePanel(Panel newPanel)
    {
        newPanel.ClosePanel();
    }

    #region GameState

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
        ChangePanel(_menuPanel);
    }
    void HandleGame()
    {
        ChangePanel(_gamePanel);
    }
    void HandleEnd()
    {
        ChangePanel(_endGamePanel);
    }
    void HandleWait()
    {
    }

    public void HandleOpenSettings()
    {
        ChangePanel(_settingPanel, true);
    }

    public void HandleCloseSettings()
    {
        ChangePanel(_menuPanel);
    }

    public void HandleOpenPause()
    {
        ChangePanel(_pausePanel, true);
    }

    public void HandleClosePause()
    {
        ChangePanel(_gamePanel);
    }

    #endregion

}
