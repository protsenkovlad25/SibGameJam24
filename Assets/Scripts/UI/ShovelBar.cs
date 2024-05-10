using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShovelBar : MonoBehaviour
{
    [SerializeField] private Slider m_Slider;
    [SerializeField] private Image m_MainIcon;
    [SerializeField] private Sprite m_ActiveIcon;
    [SerializeField] private Sprite m_UnactiveIcon;

    private void Start()
    {
        Hero.OnActiveShovel.AddListener(ActivaShovel);
        Hero.OnShovelCharged.AddListener(ShovelCharged);
        Hero.OnShovelCooldown.AddListener(ChargeShovel);
    }

    private void ChargeShovel()
    {
        m_Slider.DOValue(1, PlayerData.HeroData.ShovelCooldown).SetEase(Ease.Linear);
    }

    private void ActivaShovel()
    {
        m_Slider.value = 0;
        m_MainIcon.sprite = m_UnactiveIcon;
    }

    private void ShovelCharged()
    {
        m_MainIcon.sprite = m_ActiveIcon;
    }
}
