using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelUIPanel : UIPanel
{
	[SerializeField] private Transform m_CardsContainer;
	[SerializeField] private UpgradeCardsConfig m_CardsConfig;

	private List<UpgradeCard> m_Cards;

	protected override void OnHideComplete()
	{
		_levelSceneLoader.LoadNextLevel();
	}

	protected override void Awake()
	{
		base.Awake();

		m_CardsContainer.GetComponent<RectTransform>().localScale = Vector3.zero;
	}

	public override void Show()
	{
		base.Show();

		InitCards();

		m_CardsContainer.DOScale(Vector3.one, 1).SetEase(Ease.OutBack);
    }

	public override void Hide()
	{
		base.Hide();

        m_CardsContainer.DOScale(Vector3.one, 1).SetEase(Ease.InBack);
    }

	private void InitCards()
	{
		m_Cards = new List<UpgradeCard>();

		List<CardData> cards = new List<CardData>();
		cards.AddRange(m_CardsConfig.Cards);

		UpgradeCard card;
		GameObject prefab;
		for (int i = 0; i < 3; i++)
		{
			prefab = cards[Random.Range(0, cards.Count)].CardPrefab;

			card = Instantiate(prefab, m_CardsContainer).GetComponent<UpgradeCard>();
			m_Cards.Add(card);

			cards.Remove(cards.Find(c => c.CardPrefab == prefab));
		}
	}
}
