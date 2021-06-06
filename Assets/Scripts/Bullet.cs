using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ReactionHandler reactionHandler;
    public Substance Substance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            Destroy(collision.gameObject);
            MakeReacition(collision.gameObject);
        }

        if (collision.gameObject.name != "Player")
            Destroy(gameObject);
    }

    private void MakeReacition(GameObject second)
    {
        var rnd = new System.Random();
        var secondTr = second.GetComponent<Transform>();
        var firstFormula = Substance.Formula;
        var secondFormula = second.GetComponent<Enemy>().Substance.Formula;
        var products = reactionHandler.reactions[firstFormula.GetHashCode() + secondFormula.GetHashCode()];

        foreach(var product in products)
        {
            var newPos = secondTr.position + new Vector3(rnd.Next(-1, 1), rnd.Next(-1, 1));
            var productPrefab = Instantiate(Resources.Load<GameObject>("Product"), newPos, secondTr.rotation);
            var prSubs = productPrefab.GetComponent<Product>().Substance = product;
        }
    }

    void Start()
    {
        reactionHandler = GameObject.Find("ReactionHandler").GetComponent<ReactionHandler>();
    }

    void Update()
    {

    }
}
