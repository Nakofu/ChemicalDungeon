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
        switch (Substance.AggrState)
        {
            case "Liquid":
                spr.sprite = liquidSpr;
                break;
            case "Solid":
                spr.sprite = solidSpr;
                break;
            case "Gas":
                spr.sprite = gasSpr;
                break;
        }

        text = transform.GetChild(0).gameObject;
        text.GetComponent<TextMesh>().text = Substance.Formula;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            Destroy(gameObject);
    }

    private void Update()
    {
        
    }
}
