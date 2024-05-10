using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    public System.Action OnActivated;

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
        OnActivated?.Invoke();
        HideAnim();
    }

    private void HideAnim()
    {
        transform.DOScaleX(0f, 0.5f);
    }
}
