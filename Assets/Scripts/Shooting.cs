using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce;

    // Start is called before the first frame update
    private void Start()
    {
        bulletForce = 10f;
        firePoint = transform.GetChild(0).GetComponent<Transform>();//GameObject.Find("firePoint").GetComponent<Transform>();
        bulletPrefab = Resources.Load<GameObject>("bullet");//GameObject.Find("bullet");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        var rbBul = bullet.GetComponent<Rigidbody2D>();
        rbBul.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
