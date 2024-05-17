using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnRotatableObject : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        transform.eulerAngles = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
