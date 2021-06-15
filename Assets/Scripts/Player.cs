using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private Vector2 mousePos;
    public float MouseAngle;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = FindObjectOfType<Camera>().ScreenToWorldPoint(Input.mousePosition);

        if (movement.x != 0 || movement.y != 0)
            animator.SetBool("isMoving", true);
        else
            animator.SetBool("isMoving", false);

        if (Input.GetButtonDown("Fire1") && !PauseMenu.GameIsPaused)
            transform.GetChild(0).GetChild(0).gameObject.GetComponent<Gun>().Shoot();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        var lookDir = mousePos - rb.position;
        MouseAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        if (MouseAngle < -90 || MouseAngle > 90)
            transform.localScale = new Vector3(-3.0f, 3.0f, 3.0f);
        else
            transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
        animator.SetFloat("Angle", MouseAngle);
    }
}
