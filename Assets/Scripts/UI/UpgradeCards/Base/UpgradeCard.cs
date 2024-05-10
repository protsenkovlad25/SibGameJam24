using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCard : MonoBehaviour
{
    [SerializeField] protected Image m_Image;
    [SerializeField] protected TMP_Text m_Text;

    public virtual void Activate()
    {
    }
}
