using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Sprite liquidSpr;
    [SerializeField] private Sprite solidSpr;
    [SerializeField] private Sprite gasSpr;
    [SerializeField] private GameObject text;
    public Substance Substance;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("PickUp" + new System.Random().Next(1, 4));
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        spr.color = Substance.Color;
    }
}
