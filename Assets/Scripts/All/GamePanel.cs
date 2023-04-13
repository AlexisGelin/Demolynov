using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : Panel
{
    public int PowerUpFreezeCoeff = 1;

    [SerializeField] TMP_Text _totalTime;

    float _countdown;

    [Header("Player1")]
    [SerializeField] TMP_Text _score;

    bool _isPartyStart;

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }

    public override void Init()
    {
        base.Init();
        _isPartyStart = false;
        _countdown = 180;
    }

    private void Update()
    {
        if (_isPartyStart && GameManager.Instance.GameState == GameState.GAME)
        {
            _countdown -= 1 * Time.deltaTime * PowerUpFreezeCoeff;

            if (_countdown <= 0)
            {
                _countdown = 0;
                GameManager.Instance.UpdateStateToEnd();
            }

            TimeSpan timeSpan = TimeSpan.FromSeconds(_countdown);
            string timeText = string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes);

            _totalTime.text = "Time left\n" + timeText;
        }
    }
}
