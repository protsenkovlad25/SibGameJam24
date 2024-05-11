using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShovelBar : MonoBehaviour
{
    [SerializeField] private Slider m_Slider;
    [SerializeField] private Image m_MainIcon;
    [SerializeField] private Sprite m_ActiveIcon;
    [SerializeField] private Sprite m_UnactiveIcon;

    private Sequence m_STSequense;

    private Camera m_Camera;

    private void Start()
    {
        Hero.OnActiveShovel.AddListener(ActivaShovel);
        Hero.OnShovelCharged.AddListener(ShovelCharged);
        Hero.OnShovelCooldown.AddListener(ChargeShovel);
		m_Camera = Camera.main;

	}

    private void ChargeShovel()
    {
        //m_STSequense?.Kill();
        m_Slider.DOKill();

        m_Slider.value = 0;
        m_Slider.DOValue(1, PlayerData.HeroData.ShovelCooldown).SetEase(Ease.Linear);
    }

    private void ActivaShovel()
    {
        SoundManager.Instance.PlayEffect(PoolType.Addictive, "Shovel.rpp-00"+Random.Range(1,5), m_Camera.transform.position);
        m_Slider.DOValue(0, PlayerData.HeroData.ShovelTime);

        m_MainIcon.sprite = m_UnactiveIcon;
    }

    private void ShovelCharged()
    {
        m_MainIcon.sprite = m_ActiveIcon;
    }
}
