using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform player;
    private Transform target;
    public float range = 15f;
    public float turnSpeed = 10f;
    public float fireRate = 0.5f;
    private float fireCountdown = 1f;
    public GameObject bulletPrefab;
    public Transform firePoint;


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Start()
    {
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        player = playerObject[0].transform;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() {
        float distanceToTarget = Vector3.Distance(transform.position, player.position);
        if (distanceToTarget <= range) {
            target = player;
        } else {
            target = null;
        }
    }

    void Shoot() {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        
        if (bullet != null)
            bullet.Seek(target);
    }

    void Update()
    {
        if (target == null)
            return;

        // Target lock on
        Vector3 direction = - (target.position - transform.position);
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f) {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }
}
