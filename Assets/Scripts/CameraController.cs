using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;

    private Vector3 m_StartPosition;

    public void Start()
    {
        m_StartPosition = m_Target.position - Camera.main.transform.position;
    }

    private void Update()
    {
        Camera.main.transform.position = new Vector3(m_Target.position.x - m_StartPosition.x, m_Target.position.y - m_StartPosition.y, Camera.main.transform.position.z);
    }
}
