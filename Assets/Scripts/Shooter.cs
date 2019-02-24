﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectileType;
    public float cooldownTime;
    public Vector3 offset;

    private bool m_CanShoot;

    protected Transform m_Transform;

    #region Public Functions

    public void Shoot()
    {
        if (m_CanShoot)
        {
            Vector3 spawnOffset = (m_Transform.right * offset.x) + (m_Transform.up * offset.y) + (m_Transform.forward * offset.z);
            Vector3 spawnPosition = new Vector3(m_Transform.position.x + spawnOffset.x,
                                                m_Transform.position.y + spawnOffset.y,
                                                m_Transform.position.z + spawnOffset.z);

            Instantiate(projectileType, spawnPosition, m_Transform.rotation);

            StartCoroutine(Cooldown());
        }
    }

    /*
    public void ShootTowardsMouse()
    {
        Vector2 worldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = new Vector3(worldMouse.x - m_Transform.position.x,
                                  worldMouse.y - m_Transform.position.y, 0);

        //Debug.Log($"{v.normalized}  {v}");

        Vector3 spawnPosition = m_Transform.position + dir.normalized;

        GameObject newProjectile = Instantiate(projectileType, spawnPosition, Quaternion.identity) as GameObject;

        //newProjectile.GetComponent<Projectile>().m_Direction = dir.normalized;
    }
    */

    #endregion

    private void Start()
    {
        m_Transform = this.gameObject.transform;

        m_CanShoot = true;
    }

    private IEnumerator Cooldown()
    {
        m_CanShoot = false;
        yield return new WaitForSeconds(cooldownTime);
        m_CanShoot = true;
    }
}
