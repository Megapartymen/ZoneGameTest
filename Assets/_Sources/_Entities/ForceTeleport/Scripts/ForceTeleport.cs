using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTeleport : MonoBehaviour
{
    [SerializeField] private Transform _player;
    
    private bool _isPlayerFound;
    private float _timeToFindPlayer;
    private Fader _fader;

    private void Awake()
    {
        _fader = FindObjectOfType<Fader>();
    }

    public void SetNewPlayerPosition(Vector3 position, bool isNeedFadeOut = true)
    {
        StartCoroutine(SetNewPlayerPositionCoroutine(position, isNeedFadeOut));
    }
    
    public void SetNewPlayerPosition(Transform position, bool isNeedFadeOut = true)
    {
        StartCoroutine(SetNewPlayerPositionCoroutine(position.position, isNeedFadeOut));
    }

    private IEnumerator SetNewPlayerPositionCoroutine(Vector3 position, bool isNeedFadeOut = true)
    {
        float fadeTime = 0.5f;
        _fader.FadeIn(fadeTime);
        yield return new WaitForSeconds(fadeTime);
        _player.position = position;

        if (isNeedFadeOut)
            _fader.FadeOut(fadeTime);
    }
}
