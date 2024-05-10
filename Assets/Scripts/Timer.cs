using UnityEngine;
using UnityEngine.Events;

public class Timer
{
    public UnityEvent OnTimesUp = new UnityEvent();

    private float m_PassedTime;
    private float m_Time;
    private bool m_IsPause;

    public float CurrentTime
    {
        get { return m_Time - m_PassedTime; }
        private set { }
    }

    public float PassedTime => m_PassedTime;
    public float TotalTime => m_Time;
    public bool IsPause => m_IsPause;

    public Timer(float time)
    {
        m_PassedTime = 0;
        m_Time = time;
    }
    public void IncreaseTimer(float delta)
    {
        m_Time += delta;
    }
    public void Update(bool isScaled = true)
    {
        if (!m_IsPause)
        {
            if (isScaled)
                m_PassedTime += Time.deltaTime;
            else
                m_PassedTime += Time.unscaledDeltaTime;


            if (m_PassedTime >= m_Time)
            {
                Pause();
                OnTimesUp?.Invoke();
            }
        }
    }

    public void Reset()
    {
        m_PassedTime = 0;
        m_IsPause = false;
    }

    public void Pause()
    {
        m_IsPause = true;
    }

    public void Play()
    {
        m_IsPause = false;
    }
}
