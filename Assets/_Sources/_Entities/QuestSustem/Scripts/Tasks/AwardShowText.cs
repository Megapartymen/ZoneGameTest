using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using DG.Tweening;

public class AwardShowText : TaskAward
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _timeToShow;
    [SerializeField] private float _showDelay;

    public override void GetAward()
    {
        var sequence = DOTween.Sequence();
        sequence
            .AppendInterval(_showDelay)
            .Append(_canvasGroup.DOFade(1, 1))
            .AppendInterval(_timeToShow)
            .Append(_canvasGroup.DOFade(0, 1));


    }
}