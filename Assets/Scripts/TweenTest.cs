using System;
using UnityEngine;
using DG.Tweening;

public class TweenTest : MonoBehaviour {
    private void Start()
    {
        transform.DOMove(new Vector3(0, 2.5f, 0), 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }
}
