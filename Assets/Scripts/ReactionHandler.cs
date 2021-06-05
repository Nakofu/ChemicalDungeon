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
                new Substance("Liquid", Color.white, "H20"),
                new Substance("Liquid", Color.yellow, "AgI")
            }
        };
    }

    void Update()
    {
        
    }
}
