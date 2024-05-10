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
        UpdateHearts();

        Hero.OnChangeHP.AddListener(ChangeHeroHP);
    }

    private void UpdateHearts()
    {
        List<Image> hearts = new List<Image>();
        hearts.AddRange(GetComponentsInChildren<Image>());

        for (int i = 0; i < hearts.Count; i++)
        {
            Destroy(hearts[0]);
        }

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
