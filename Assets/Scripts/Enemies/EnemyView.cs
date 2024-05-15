using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    ComplexParticleSystem m_Particles;
    SpriteRenderer m_SpriteRenderer;


    public ComplexParticleSystem Particles => m_Particles;
    public SpriteRenderer Sprite => m_SpriteRenderer;

    public void Init()
    {
        m_Particles = GetComponentInChildren<ComplexParticleSystem>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Dead()
    {
        Sprite.enabled = false;

        m_Particles.PlayParticle();

        int number = Random.Range(1, 6);
        SoundManager.Instance.PlayEffect(PoolType.Enemies, "Enemy_Damage_" + (PlayerData.Level + 1) + ".rpp-00" + number, transform.position);
    }
}
