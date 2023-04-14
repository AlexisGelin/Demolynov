using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePanel : Panel
{
    public int PowerUpFreezeCoeff = 1;

    [SerializeField] TMP_Text _totalTime;
    [SerializeField] GameObject _totalTouch;

    public string TimeString;
    float _countdown;


    bool _isPartyStart;

    public override void OpenPanel()
    {
        _isPartyStart = true;

        StartCoroutine(DisableTouch());

        base.OpenPanel();
    }

    IEnumerator DisableTouch()
    {
        _totalTouch.SetActive(true);
        yield return new WaitForSeconds(30);
        _totalTouch.SetActive(false);
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
    }

    public override void Init()
    {
        base.Init();
        _isPartyStart = false;
        _countdown = 60;
    }

    public void AddTime()
    {
        _countdown += 2;
        _totalTime.GetComponent<RectTransform>().localScale = Vector3.one;
        _totalTime.GetComponent<RectTransform>().DOPunchScale(new Vector3(.2F, .2f, .2F), .2f).OnComplete(() => _totalTime.GetComponent<RectTransform>().localScale = Vector3.one);
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

            int minutes = Mathf.FloorToInt(_countdown / 60);
            int seconds = Mathf.FloorToInt(_countdown - minutes * 60f);

            TimeString = string.Format("{0:D2}:{1:D2}", minutes, seconds);

            _totalTime.text = "Temps restant\n" + TimeString;
        }
    }
}