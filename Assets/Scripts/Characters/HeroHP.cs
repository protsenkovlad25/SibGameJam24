using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHP : MonoBehaviour
{
    [SerializeField] private Sprite m_ActiveHeart;
    [SerializeField] private Sprite m_DisactiveHeart;

    private List<Image> m_Hearts;

    private void Start()
    {
        m_Hearts = new List<Image>();
        m_Hearts.AddRange(GetComponentsInChildren<Image>());

        Hero.OnChangeHP.AddListener(ChangeHeroHP);
    }

    private void ChangeHeroHP(int health)
    {
        for (int i = m_Hearts.Count; i > 0; i--)
        {
            if (i > health)
            {
                m_Hearts[i - 1].sprite = m_DisactiveHeart;
            }
            else
            {
                m_Hearts[i - 1].sprite = m_ActiveHeart; 
            }
        }
    }
}
