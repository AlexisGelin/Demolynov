using DG.Tweening;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void Start()
    {
        transform.DORotate(new Vector3(0, 360, 0), 10.0f, RotateMode.FastBeyond360).SetRelative()
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
        
        transform.DOMoveY( 1, 1f)
            .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        
        
    }
}