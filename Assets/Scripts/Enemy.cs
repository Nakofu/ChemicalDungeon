using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private GameObject text;
    [SerializeField] private Substance substance;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform tr;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    private Vector2 movement;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).gameObject;
        substance = GetComponent<Substance>();
        text.GetComponent<TextMesh>().text = substance.Formula;
        spr.color = substance.Color;
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (playerPos.position.x > tr.position.x)
            movement.x++;
        if (playerPos.position.x < tr.position.x)
            movement.x--;
        if (playerPos.position.y > tr.position.y)
            movement.y++;
        if (playerPos.position.y < tr.position.y)
            movement.y--;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        movement = new Vector2(0, 0);
    }
}
