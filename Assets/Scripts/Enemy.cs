using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Sprite liquidSpr;
    [SerializeField] private Sprite solidSpr;
    [SerializeField] private Sprite gasSpr;
    [SerializeField] private GameObject text;
    [SerializeField] private Transform playerPos;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private float moveSpeed;

    public float ChosenMoveSpeed;
    public Substance Substance;


    public void SetSpeed()
    {
        moveSpeed = ChosenMoveSpeed;
    }

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        spr.color = Substance.Color;
        spr.sprite = Substance.AggrState switch
        {
            "Liquid" => liquidSpr,
            "Solid" => solidSpr,
            "Gas" => gasSpr,
            _ => throw new System.ArgumentException("The chosen aggregate state doesn't have a sprite: " + Substance.AggrState)
        };

        text = transform.GetChild(0).gameObject;
        text.GetComponent<TextMesh>().text = Substance.Formula;

        playerPos = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        movement = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        Move();
        spr.color = Substance.Color;
    }

    private void Move()
    {
        if (playerPos.position.x > transform.position.x)
            movement.x++;
        if (playerPos.position.x < transform.position.x)
            movement.x--;
        if (playerPos.position.y > transform.position.y)
            movement.y++;
        if (playerPos.position.y < transform.position.y)
            movement.y--;

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        movement = new Vector2(0, 0);
    }
}
