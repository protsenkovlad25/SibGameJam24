using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    [SerializeField] TMP_Text m_Text;
    void Start()
    {
        m_Text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMod;


        if ((transform.position - Hero.HeroTransform.position).magnitude <= 15)
            distanceMod = 1 - ((transform.position - Hero.HeroTransform.position).magnitude / 15f);
        else
            distanceMod = 0;
        m_Text.color = new Color(1, 1, 1, .5f * distanceMod);
    }
}
