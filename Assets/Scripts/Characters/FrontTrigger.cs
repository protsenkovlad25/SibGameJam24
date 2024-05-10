using System;
using UnityEngine;

public class FrontTrigger : MonoBehaviour
{
    public Action OnFrontTriggered;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Front Triggerred " + other.name);

        OnFrontTriggered?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Front Triggerred Col " + collision.gameObject.name);

        OnFrontTriggered?.Invoke();
    }
}
