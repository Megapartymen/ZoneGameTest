using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    [SerializeField] private AudioSource _ambientSound;

    private void Start()
    {
        _ambientSound.Play();
    }
}
