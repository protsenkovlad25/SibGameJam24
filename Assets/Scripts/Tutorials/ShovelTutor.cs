using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelTutor : TutorialTrigger
{
    protected override bool Check()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
