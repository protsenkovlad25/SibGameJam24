using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] protected Image m_Image;
    [SerializeField] protected TMP_Text m_Text;
    [SerializeField] protected float m_Value;

    public virtual string Description { get; }

    private void Start()
    {
        m_Text.text = Description;
    }

    public virtual void Activate()
    {
    }
}
