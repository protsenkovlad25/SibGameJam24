using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade Cards Config", menuName = "Configs/UpgradeCardsConfig")]
public class UpgradeCardsConfig : ScriptableObject
{
    [SerializeField] private List<CardData> m_Cards;

    public List<CardData> Cards => m_Cards;
}

[Serializable]
public class CardData
{
    [SerializeField] private string m_Name;
    [SerializeField] private GameObject m_CardPrefab;
}
