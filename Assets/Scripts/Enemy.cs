using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spr;
    [SerializeField] private GameObject text;
    [SerializeField] private Substance substance;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).gameObject;
        substance = GetComponent<Substance>();
        text.GetComponent<TextMesh>().text = substance.Formula;
        //spr.color = substance.Color;
        spr.color = substance.Color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
