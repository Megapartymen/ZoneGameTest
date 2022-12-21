using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardPlaySound : TaskAward
{
    [SerializeField] private AudioSource _audioSource;
    
    public override void GetAward()
    {
        _audioSource.Play();
    }
}
