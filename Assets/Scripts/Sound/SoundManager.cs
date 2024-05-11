using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public enum PoolType { Weapon, UI, Addictive, Enemies}

[Serializable]
public class SoundEffectData
{
    public string name;
    public AudioClip clip;
}
[System.Serializable]
public struct Music
{
    public AudioClip LightLayer;
    public List<AudioClip> ActionLayers;
}
[System.Serializable]
public struct EffectPool
{
    public PoolType type;
    public List<SoundEffectData> effects;
}

public class SoundManager : MonoBehaviour
{
    [System.Serializable]
    public enum MusicState { Menu, GamePlay, ZombiRush}
    [SerializeField] GameObject m_SoundEffect;

    [SerializeField] List<EffectPool> m_EffectPools;

    List<GameObject> m_EffectObjects;

    [SerializeField] List<Music> m_Music;

    public static SoundManager Instance { get; private set; }

    [SerializeField] private int m_MaxEffectCount;

    GameObject m_LightLayer;
    List<GameObject> m_ActionLayers;

    bool m_IsActionMoment = false;

	private void Start()
	{
        Init();
	}

	public void Init()
    {
        if(Instance == null)
        {
            m_EffectObjects = new List<GameObject>();
            Instance = this;
            DontDestroyOnLoad(gameObject);
            for (int i = 0; i < m_MaxEffectCount; i++)
            {
                m_EffectObjects.Add(Instantiate(m_SoundEffect, transform).gameObject);
                m_EffectObjects[i].SetActive(false);
                DontDestroyOnLoad(m_EffectObjects[i]);
            }
            m_IsActionMoment = false;
            //InitMusic();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnValidate()
    {
        foreach(var pool in m_EffectPools)
            foreach (var effect in pool.effects)
                if(effect.clip!=null)
                    effect.name = effect.clip.name;
    }

    public void PlayMusic(AudioClip audioClip)
    {
        AudioSource audioSource = Camera.main.GetComponent<AudioSource>();

		audioSource.clip = audioClip;
        audioSource.Play();

	}

    /*public void InitMusic()
    {
        if(m_LightLayer!=null)
        {
            Destroy(m_LightLayer);
            foreach (var a in m_ActionLayers) Destroy(a);
            m_ActionLayers.Clear();
        }

        m_ActionLayers = new List<GameObject>();
        Music currentMusic = m_Music[0];
        m_Music.RemoveAt(0);
        m_Music.Add(currentMusic);

        m_LightLayer = InitNewMusicLayer(currentMusic.LightLayer);

        m_LightLayer.GetComponent<AudioSource>().clip = currentMusic.LightLayer;
        m_LightLayer.name = "LightLayer";


        for(int i = 0; i< currentMusic.ActionLayers.Count; i++)
        {
            m_ActionLayers.Add(InitNewMusicLayer(currentMusic.ActionLayers[i]));
            m_ActionLayers[i].name = "ActionLayer" + i;
        }

        SwitchActionMoment(m_IsActionMoment);
    }*/
    /*public void SetMusicVolume()
    {
        float volume = SettingsController.GetFloatValue("musicVolume");
        m_LightLayer.GetComponent<AudioSource>().volume = volume / 100f;

        if (m_IsActionMoment) foreach (var a in m_ActionLayers) a.GetComponent<AudioSource>().DOFade(volume/100f,4);
        else foreach (var a in m_ActionLayers) a.GetComponent<AudioSource>().DOFade(0, 2);
    }*/
    /*public void SwitchActionMoment(bool isAction)
    {
        m_IsActionMoment = isAction;

        SetMusicVolume();
    }*/
    GameObject InitNewMusicLayer(AudioClip clip)
    {
        var newLayer = new GameObject();
        newLayer.AddComponent<AudioSource>();
        newLayer.transform.parent = transform;

        newLayer.GetComponent<AudioSource>().clip = clip;

        newLayer.GetComponent<AudioSource>().Play();

        newLayer.GetComponent<AudioSource>().volume = 0;
        newLayer.GetComponent<AudioSource>().priority = 1000;

        return newLayer;
    }
    public void PlayEffect(PoolType usingPool, string effectName, Vector3 position, bool isUI = false)
    {
        var pool = m_EffectPools.Find(x => x.type == usingPool);

        if (pool.effects.Exists(x => x.name == effectName))
        {
            if (!m_EffectObjects.Exists(x => x.activeInHierarchy == false))
            {
                m_EffectObjects[0].SetActive(false);
                m_EffectObjects.Add(m_EffectObjects[0]);
                m_EffectObjects.RemoveAt(0);
            }
            var newEffect = m_EffectObjects.Find(x => x.activeInHierarchy == false);

            newEffect.GetComponent<SoundEffect>().Initialize(pool.effects.Find(x => x.name == effectName).clip,isUI);
            newEffect.transform.position = position;
            //Debug.Log("Sound <" + effectName + "> from the pool <" + usingPool + "> is playing!");
        }
        else
        {
            Debug.LogError("Dont find sound <" + effectName + "> in the pool <" + usingPool + ">");
        }
    }
    public AudioClip GetEffect(PoolType usingPool, string effectName)
    {
        var pool = m_EffectPools.Find(x => x.type == usingPool);
        if (pool.effects.Exists(x => x.name == effectName))
        {
            return pool.effects.Find(x => x.name == effectName).clip;
        }
        return null;
    }
    private void Update()
    {
        //if (!m_LightLayer.GetComponent<AudioSource>().isPlaying)
            //InitMusic();
    }
}
