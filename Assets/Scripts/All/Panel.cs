using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    [SerializeField] RectTransform _rectTransform;
    [SerializeField] CanvasGroup _canvasGroup;

    public virtual void Init()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.interactable = true;
        _canvasGroup.alpha = 0;
    }

    public virtual void OpenPanel()
    {
        _canvasGroup.DOFade(1, .2f).OnComplete(() =>
        {
            _canvasGroup.blocksRaycasts = true;
        }).SetUpdate(UpdateType.Normal, true);


    }

    public virtual void ClosePanel()
    {
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.DOFade(0, .2f).SetUpdate(UpdateType.Normal, true);
    }

}
