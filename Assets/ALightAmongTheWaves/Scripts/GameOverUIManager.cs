using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using RedSpace;

public class GameOverUIManager : Singleton<GameOverUIManager>
{
    [SerializeField] protected Canvas canvas;
    [SerializeField] protected CanvasGroup canvasGroup;

    public IEnumerator ShowGameOverPanel(float time)
    {
        canvas.gameObject.SetActive(true);
        canvasGroup.alpha = 0f;
        yield return canvasGroup.DOFade(1f, time).SetEase(Ease.InSine).WaitForCompletion();
    }
}
