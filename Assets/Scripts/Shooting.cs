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
    void Start()
    {
        bulletForce = 10f;
        firePoint = GameObject.Find("firePoint").GetComponent<Transform>();
        bulletPrefab = Resources.Load<GameObject>("bullet");//GameObject.Find("bullet");
    }

    // Update is called once per frame
    void Update()
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
        //var vec = new Vector2()
        rbBul.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
