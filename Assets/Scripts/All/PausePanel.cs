using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PausePanel : Panel
{
    [SerializeField] GamePanel gamePanel;

    [SerializeField] TMP_Text _totalObjectDestroy, _timeLeft;

    [SerializeField] Score _P1Score, _P2Score;

    public override void OpenPanel()
    {
        base.OpenPanel();
        _timeLeft.text = gamePanel.TimeString;

        _totalObjectDestroy.text = (_P1Score.TotalObjectDestroy + _P2Score.TotalObjectDestroy).ToString();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }

    public override void Init()
    {
        base.Init();
    }
}
