using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HeroWeapon : MonoBehaviour
{
    [SerializeField] private Projectile m_Projectile;
    [SerializeField] private GameObject m_Gun;
    [SerializeField] private GameObject m_Char;
    [SerializeField] private Transform m_Muzzle;

    [SerializeField] float m_Range;
    [SerializeField] float m_Delay;
    [SerializeField] float m_Spread;
    [SerializeField] float m_BulletsCount;

    float m_CurrentDelay;

    private Camera m_Camera;


    private void Awake()
    {
        m_Camera= Camera.main;

        CalcRotation();
    }
    Vector2 GetMousePosition()
    {
        Vector3 result = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return result;
    }
    void CalcRotation()
    {
        Vector3 mousePos = GetMousePosition();

        float angle = Vector3.SignedAngle(new Vector3(1,0),
            mousePos - m_Gun.transform.position,
            new Vector3(0, 0, 1));

        m_Gun.transform.eulerAngles = new Vector3(0, 0, angle);
        if (m_Gun.transform.localEulerAngles.z > 90 && m_Gun.transform.localEulerAngles.z < 270)
        {
            m_Gun.GetComponentInChildren<SpriteRenderer>().flipY = m_Char.GetComponentInChildren<SpriteRenderer>().flipX = true;
        }
        else
        {
            m_Gun.GetComponentInChildren<SpriteRenderer>().flipY = m_Char.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
    }
    private void Shoot()
    {
        m_CurrentDelay = m_Delay;

        for (int i = 0; i < m_BulletsCount; i++)
        {
            var proj = Instantiate(m_Projectile);

            proj.transform.position = m_Muzzle.transform.position;

            proj.GetComponent<HeroProjectile>().SetRange(m_Range);
            proj.transform.parent = transform;

            proj.transform.eulerAngles = new Vector3(0, 0, m_Gun.transform.eulerAngles.z + Random.Range(-m_Spread, m_Spread));
        }
    }
    private void Update()
    {
        CalcRotation();

        if (m_CurrentDelay > 0) m_CurrentDelay -= Time.deltaTime;

        if(Input.GetMouseButton(0) && m_CurrentDelay <=0)
            Shoot();
    }
}
