using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public TMP_Text Text;
    Sequence _tween;

    public void InitSmall(int price, int multiplier)
    {
        Text.alpha = 1;
        Text.transform.localPosition = Vector3.up;
        Text.transform.localScale = Vector3.one;
        Text.text = (price * multiplier).ToString();

        switch (multiplier)
        {
            case >= 5:
                Text.color = ColorManager.Instance._multiplicator5;
                break;
            case >= 4:
                Text.color = ColorManager.Instance._multiplicator4;
                break;
            case >= 3:
                Text.color = ColorManager.Instance._multiplicator3;
                break;
            case >= 2:
                Text.color = ColorManager.Instance._multiplicator2;
                break;
            case >= 1:
                Text.color = ColorManager.Instance._multiplicator1;
                break;

        }

        if (_tween.IsActive()) _tween.Kill();

        _tween = DOTween.Sequence();

        _tween
            .Join(Text.transform.DOPunchScale(new Vector3(1.2f, 1.2f, 1.2f), .1f))
            .Append(Text.transform.DOLocalMoveY(2f, 1f)).SetEase(Ease.InQuad)
            .Append(Text.DOFade(0, .2f));
    }
}
