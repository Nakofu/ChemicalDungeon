using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletForce;
    private Vector3 shootVector;
    private Quaternion bulletRot;
    public Substance Substance;

    public void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, bulletRot);// transform.rotation);
        bullet.GetComponent<Bullet>().Substance = Substance;
        bullet.GetComponent<Rigidbody2D>().AddForce(shootVector * bulletForce, ForceMode2D.Impulse);
    }

    private void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("bullet");
    }


    void Update()
    {
        var playerMov = transform.GetComponentInParent<PlayerControl>().movement;
        var playerPos = transform.parent.transform.position;

        if (playerMov.x == 1 && playerMov.y == 0)
        {
            transform.position = new Vector3(playerPos.x + 1.1f, playerPos.y - 0.1f);
            bulletRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
            shootVector = transform.right;
        }

        if (playerMov.x == -1 && playerMov.y == 0)
        {
            transform.position = new Vector3(playerPos.x - 1.1f, playerPos.y - 0.1f);
            bulletRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
            shootVector = -transform.right;
        }

        if (playerMov.x == 0 && playerMov.y == 1)
        {
            transform.position = new Vector3(playerPos.x + 0.3f, playerPos.y + 1.3f);
            bulletRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            shootVector = transform.up;
        }

        if (playerMov.x == 0 && (playerMov.y == -1 || playerMov.y == 0))
        {
            transform.position = new Vector3(playerPos.x - 0.0f, playerPos.y - 0.9f);
            bulletRot = Quaternion.Euler(new Vector3(0.0f, 0.0f, 90.0f));
            shootVector = -transform.up;
        }
    }
}
