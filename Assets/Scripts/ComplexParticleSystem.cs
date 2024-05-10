using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class ComplexParticleSystem : MonoBehaviour
    {
        private List<ParticleSystem> m_Particles;

        private bool m_IsPlaying = false;

        public void Init()
        {
            m_Particles = new List<ParticleSystem>();

            if (TryGetComponent<ParticleSystem>(out var p))
                m_Particles.Add(p);

            foreach (Transform child in transform)
            {
                if (child.TryGetComponent<ParticleSystem>(out var particle))
                    m_Particles.Add(particle);
            }
        }

        public virtual void PlayParticle()
        {
            if (m_Particles == null)
                Init();

            foreach (var particle in m_Particles)
                particle.Play();

            m_IsPlaying = true;
        }

        public void StopParticle()
        {
            foreach (var particle in m_Particles)
                particle.Stop();
        }

        private void CheckParticlePlaying()
        {
            int notPlayingCount = 0;
            foreach (var particle in m_Particles)
            {
                if (!particle.isPlaying) notPlayingCount++;
            }

            if (notPlayingCount == m_Particles.Count) Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            if (m_IsPlaying && transform.parent == null) CheckParticlePlaying();
        }
    }
