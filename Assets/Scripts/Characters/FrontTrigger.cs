using System;
using UnityEngine;

public class FrontTrigger : MonoBehaviour
{
    public Action OnFrontTriggered;

    private void OnTriggerEnter(Collider other)
    {
        OnFrontTriggered?.Invoke();
    }
}
