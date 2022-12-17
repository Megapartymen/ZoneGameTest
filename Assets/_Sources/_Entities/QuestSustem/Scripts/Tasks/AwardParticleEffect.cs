using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class AwardParticleEffect : TaskAward
{
    [SerializeField] private ParticleSystem _effect;

    public override void GetAward()
    {
        _effect.Play();
    }
}