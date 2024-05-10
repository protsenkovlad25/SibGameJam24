using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHP : MonoBehaviour
{
    [SerializeField] private GameObject m_HeartPrefab;
    [SerializeField] private Sprite m_ActiveHeart;
    [SerializeField] private Sprite m_DisactiveHeart;

    private List<Image> m_Hearts;

    private void Start()
    {
        DestroyHearts();
        InitHearts();

        Hero.OnChangeHP.AddListener(ChangeHeroHP);
    }

    private void DestroyHearts()
    {
        List<Image> hearts = new List<Image>();
        hearts.AddRange(GetComponentsInChildren<Image>());

        for (int i = hearts.Count - 1; i >= 0; i--)
        {
            Destroy(hearts[i].gameObject);
            hearts.Remove(hearts[i]);
        }
    }

    private void InitHearts()
    {
        for (int i = 0; i < PlayerData.HeroData.Health; i++)
        {
            CreateHeart();
        }

        m_Hearts = new List<Image>();
        m_Hearts.AddRange(GetComponentsInChildren<Image>());
    }

    private Image CreateHeart()
    {
        Image heart = Instantiate(m_HeartPrefab, transform).GetComponent<Image>();

        return heart;
    }

    private void ChangeHeroHP(int health)
    {
        if (PlayerData.HeroData.MaxHealth < m_Hearts.Count)
        {
            Image heart;
            for (int i = 0; i < PlayerData.HeroData.MaxHealth - m_Hearts.Count; i++)
            {
                heart = CreateHeart();
                m_Hearts.Add(heart);
            }
        }

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
