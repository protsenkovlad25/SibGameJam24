using System;
using UnityEngine;

public class FrontTrigger : MonoBehaviour
{
    public Action OnFrontTriggered;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Front Triggerred Col " + collision.gameObject.name);

        OnFrontTriggered?.Invoke();
    }
}
