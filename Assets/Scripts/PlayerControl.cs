using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;
    [SerializeField] private Animator animator;

    private Vector2 movement;
    private Vector2 mousePos;

    private void Start()
    {
        moveSpeed = 10f;
        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<Camera>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButtonDown("Fire1") && !PauseMenu.GameIsPaused)
        {
            animator.SetBool("IsShooting", true);
            transform.GetChild(0).gameObject.GetComponent<Gun>().Shoot();
        }
        if (Input.GetButtonUp("Fire1") && !PauseMenu.GameIsPaused)
        {
            animator.SetBool("IsShooting", false);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
    }
}
