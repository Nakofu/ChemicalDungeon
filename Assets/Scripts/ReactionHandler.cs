using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionHandler : MonoBehaviour
{
    public Dictionary<int, List<Substance>> reactions;

    void Start()
    {
        reactions = new Dictionary<int, List<Substance>>
        {
            ["H2".GetHashCode() + "O2".GetHashCode()] = new List<Substance>
            {
                new Substance("H20", Color.white, "Liquid")
            },
            ["H2".GetHashCode() + "Li".GetHashCode()] = new List<Substance>
            {
                new Substance("LiH", Color.cyan, "Solid")
            },
            ["H2".GetHashCode() + "Na".GetHashCode()] = new List<Substance>
            {
                new Substance("NaH", Color.white, "Solid")
            },
            ["H2".GetHashCode() + "S".GetHashCode()] = new List<Substance>
            {
                new Substance("H2S", Color.white, "Gas")
            },
            ["H2".GetHashCode() + "N2".GetHashCode()] = new List<Substance>
            {
                new Substance("NH3", Color.white, "Gas")
            },

        };
    }

    void Update()
    {
        
    }
}
