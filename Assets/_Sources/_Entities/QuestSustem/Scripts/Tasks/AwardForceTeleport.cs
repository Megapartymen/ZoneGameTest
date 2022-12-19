using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardForceTeleport : TaskAward
{
    private ForceTeleport _forceTeleport;

    private void Awake()
    {
        _forceTeleport = FindObjectOfType<ForceTeleport>();
    }

    public override void GetAward()
    {
        _forceTeleport.SetNewPlayerPosition(new Vector3(0,0.2f,0));
    }
}
