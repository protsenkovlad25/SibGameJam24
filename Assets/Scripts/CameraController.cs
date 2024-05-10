using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform m_Target;

    [SerializeField] private Transform m_UpPos;
    [SerializeField] private Transform m_DownPos;
    [SerializeField] private Transform m_LeftPos;
    [SerializeField] private Transform m_RightPos;

    private Vector2 m_MainPos;
    private Vector2 m_ViewPos;

    private float m_ChangeViewSpeed = 20f;

    private bool m_IsViewChange = false;

    public void Start()
    {
        Gravity.OnGravityChanged.AddListener(ChangeGravity);

        m_MainPos = m_Target.position - Camera.main.transform.position;
        ChangeGravity(Gravity.VectorDir);
    }

    private void ChangeGravity(Vector2 dir)
    {
        m_ViewPos = Vector3.zero;

        switch (Gravity.GravityDir)
        {
            case GravityDirection.Up: m_ViewPos = m_UpPos.localPosition; break;
            case GravityDirection.Down: m_ViewPos = m_DownPos.localPosition; break;
            case GravityDirection.Left: m_ViewPos = m_LeftPos.localPosition; break;
            case GravityDirection.Right: m_ViewPos = m_RightPos.localPosition; break;
        }

        m_IsViewChange = true;
    }

    private void MoveCamera()
    {
        transform.position = new Vector3(m_Target.position.x - m_MainPos.x,
                                                     m_Target.position.y - m_MainPos.y,
                                                     Camera.main.transform.position.z);
    }

    private void ChangeView()
    {
        //if (m_ViewPos.x > m_MainPos.x)
        //{
        //    m_MainPos.x += m_ChangeViewSpeed * Time.deltaTime;
        //}
        //else if (m_ViewPos.x < m_MainPos.x)
        //{
        //    m_MainPos.x -= m_ChangeViewSpeed * Time.deltaTime;
        //}

        //if (m_ViewPos.y > m_MainPos.y)
        //{
        //    m_MainPos.y += m_ChangeViewSpeed * Time.deltaTime;
        //}
        //else if (m_ViewPos.y < m_MainPos.y)
        //{
        //    m_MainPos.y -= m_ChangeViewSpeed * Time.deltaTime;
        //}

        m_MainPos = Vector2.Lerp(m_MainPos, m_ViewPos, .05f);


        if ((m_ViewPos - m_MainPos).magnitude < 0.1f)
        {
            m_MainPos = m_ViewPos;
            m_IsViewChange = false;
        }
    }

    private void Update()
    {
        if (m_IsViewChange) ChangeView();

        MoveCamera();
    }
}
