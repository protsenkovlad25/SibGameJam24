using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] TMP_Text m_Text;
    protected bool m_IsActivated = false;
    protected bool m_IsTextReaden = false;
    
    string m_String;
    Timer m_Timer;

    public virtual void ActivateTutorial()
    {
        if (!m_IsActivated)
        {
            m_Text.gameObject.SetActive(true); 

            m_IsActivated = true;

            m_String= m_Text.text;
            m_Text.text = "";
            WriteText();
            Time.timeScale = 0;
            PlayerInput.Lock();
            PlayerInput.LockMove();
        }
    }
    void WriteText()
    {
        if(m_String.Length > 0)
        {
            m_Timer = new Timer(.02f);
            m_Text.text += m_String[0];
            m_String = m_String.Remove(0, 1);
            m_Timer.OnTimesUp.AddListener(WriteText);
        }
        else
        {
            m_IsTextReaden = true;
        }
    }
    protected void Update()
    {
        m_Timer?.Update(false);

        if(m_IsTextReaden)
        {
            if(Check())
                UnlockGame();
        }
    }
    protected virtual void UnlockGame()
    {
        Time.timeScale = 1;
        PlayerInput.Unlock();
        PlayerInput.UnlockMove();
    }
    protected virtual bool Check()
    {
        return Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D);
    }
}
