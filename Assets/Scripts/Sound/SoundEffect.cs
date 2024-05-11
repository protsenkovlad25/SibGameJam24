using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    AudioSource source;
    bool m_IsStopable;
    [SerializeField] bool m_IsInterface = false;
    public bool IsPlayinf => source.isPlaying;
    public void Initialize(AudioClip clip, bool isUI = false, bool isStopable = true)
    {
        m_IsInterface = isUI;
        gameObject.SetActive(true);
        source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();


        float mod;

        //if (m_IsInterface) mod = SettingsController.GetFloatValue("uiSoundVolume");
        //else mod = SettingsController.GetFloatValue("soundVolume");
        //source.volume = 1*(mod/100f);


        m_IsStopable = isStopable;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsStopable)
        {
            if (!source.isPlaying)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
