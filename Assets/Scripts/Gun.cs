using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce;
    public Substance Substance;

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Bullet>().Substance = Substance;
        bullet.GetComponent<Rigidbody2D>().AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
    }

    private void Start()
    {
        bulletForce = 10f;
        bulletPrefab = Resources.Load<GameObject>("bullet");
    }


    void Update()
    {
        
    }
}
