using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private Sprite liquidSpr;
    [SerializeField] private Sprite solidSpr;
    [SerializeField] private Sprite gasSpr;
    [SerializeField] private ReactionHandler reactionHandler;
    public Substance Substance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Destroy(collision.gameObject);
            MakeReacition(collision.gameObject);
            FindObjectOfType<AudioManager>().PlaySound("DeathEnemy" + new System.Random().Next(1, 4));
        }

        if (collision.gameObject.name != "Player")
            Destroy(gameObject);
    }

    private void MakeReacition(GameObject second)
    {
        var rnd = new System.Random();
        var secondTr = second.transform;
        var firstFormula = Substance.Formula;
        var secondFormula = second.GetComponent<Enemy>().Substance.Formula;
        var products = reactionHandler.reactions[firstFormula.GetHashCode() + secondFormula.GetHashCode()];

        foreach(var product in products)
        {
            var newPos = secondTr.position + new Vector3(rnd.Next(-1, 1), rnd.Next(-1, 1));
            var productPrefab = Instantiate(Resources.Load<GameObject>("Product"), newPos, secondTr.rotation);
            productPrefab.GetComponent<Product>().Substance = product;
        }
    }

    void Start()
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

        reactionHandler = GameObject.Find("ReactionHandler").GetComponent<ReactionHandler>();
    }

    void Update()
    {

    }
}
