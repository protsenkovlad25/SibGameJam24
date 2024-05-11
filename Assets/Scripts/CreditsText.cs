using DG.Tweening;
using UnityEngine;

public class CreditsText : MonoBehaviour
{
    private void Awake()
    {
        Sequence s = DOTween.Sequence();

        s.Append(transform.DOLocalMoveY(2000, 20f).SetEase(Ease.Linear));
        s.AppendCallback(() => { Debug.Log("End Credits"); Application.Quit(); });
    }
}
