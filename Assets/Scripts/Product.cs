using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private GameObject text;
    public Substance Substance;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).gameObject;
        text.GetComponent<TextMesh>().text = Substance.Formula;
        spr.color = Substance.Color;
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
