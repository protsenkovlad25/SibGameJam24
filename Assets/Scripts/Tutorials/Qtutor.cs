using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Qtutor : TutorialTrigger
{
    protected override bool Check()
    {
        return Input.GetKeyDown(KeyCode.Q);
    }
    protected override void UnlockGame()
    {
        PlayerInput.TutorQPress();
        base.UnlockGame();
    }
}
