using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce;
    private Vector3 shootVector;

    public Substance Substance;

    public void Shoot()
    {
        FindObjectOfType<AudioManager>().PlaySound("Shot4");
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().Substance = Substance;
        bullet.GetComponent<Rigidbody2D>().AddForce(shootVector * bulletForce, ForceMode2D.Impulse);
        bullet.transform.localScale = new Vector3(System.Math.Sign(transform.parent.parent.localScale.x) * bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
    }

    private void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("bullet");
        firePoint = transform.GetChild(0).transform;
    }


    void FixedUpdate()
    {
        var angle = transform.parent.GetComponentInParent<Player>().MouseAngle;
        if (angle < -90 || angle > 90)
        {
            transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.x, transform.parent.rotation.y, angle - 180);
            shootVector = -transform.right;
        }
        else
        {
            transform.parent.rotation = Quaternion.Euler(transform.parent.rotation.x, transform.parent.rotation.y, angle);
            shootVector = transform.right;
        }
    }
}
