using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FallingDistanceTextController : MonoBehaviour
{
    TMP_Text m_Text;
    void Awake()
    {
        m_Text= GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Text.text =  Mathf.RoundToInt(PlayerData.FallingDistance).ToString() + " m.";  
    }
}
