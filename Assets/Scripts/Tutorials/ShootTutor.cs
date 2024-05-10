using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTutor : TutorialTrigger
{
    protected override bool Check()
    {
        return Input.GetMouseButtonDown(0);
    }
}
