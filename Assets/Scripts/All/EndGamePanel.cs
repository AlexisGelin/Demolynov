using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGamePanel : Panel
{
    [SerializeField] TMP_Text _subTitle, _scoreP1, _scoreP2, _totalObjectDestroyP1, _totalObjectDestroyP2, _maxComboP1, _maxComboP2;

    [SerializeField] Score _P1Score, _P2Score;

    public override void OpenPanel()
    {
        base.OpenPanel();

        if (_P1Score.GetScore() < _P2Score.GetScore())
        {
            _subTitle.text = "Le joueur 2 (Droite) gagne la partie";
        }
        else
        {
            _subTitle.text = "Le joueur 1 (Gauche) gagne la partie";
        }

        _scoreP1.text = _P1Score.GetScore().ToString();
        _totalObjectDestroyP1.text = _P1Score.TotalObjectDestroy.ToString();
        _maxComboP1.text = _P1Score.MaxCombo.ToString();

        _scoreP2.text = _P2Score.GetScore().ToString();
        _totalObjectDestroyP2.text = _P2Score.TotalObjectDestroy.ToString();
        _maxComboP2.text = _P2Score.MaxCombo.ToString();
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
