using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private float health;
    [SerializeField] private HealthBar healthBar;
    private float moveTimer;
    private float dmgTimer;
    private Vector2 movement;
    private Vector2 mousePos;
    public float MouseAngle;

    private void Start()
    {
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthBar = FindObjectOfType<HealthBar>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && !PauseMenu.GameIsPaused)
            transform.GetChild(0).GetChild(0).gameObject.GetComponent<Gun>().Shoot();
    }

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            FindObjectOfType<AudioManager>().PlaySound("DeathHero" + new System.Random().Next(1, 3));
            return;
        }

        if (movement.x != 0 || movement.y != 0)
        {
            moveTimer += Time.deltaTime;
            if (moveTimer > 0.4f)
            {
                moveTimer = 0;
                FindObjectOfType<AudioManager>().PlaySound("Walk5");
            }

            animator.SetBool("isMoving", true);
        }
        else
            animator.SetBool("isMoving", false);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        var lookDir = mousePos - rb.position;
        MouseAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (MouseAngle < -90 || MouseAngle > 90)
            transform.localScale = new Vector3(-3.0f, 3.0f, 3.0f);
        else
            transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        animator.SetFloat("Angle", MouseAngle);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            dmgTimer += Time.deltaTime;
            if (dmgTimer > 0.2f)
            {
                dmgTimer = 0.0f;
                health -= 5;
                healthBar.SetHeatlh(health);
                FindObjectOfType<AudioManager>().PlaySound("PlayerHit" + new System.Random().Next(1, 3));
            }
        }

    }
}
