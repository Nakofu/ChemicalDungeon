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
            ["H2".GetHashCode() + "CuO".GetHashCode()] = new List<Substance>
            {
                new Substance("Cu", new Color(0.74f, 0.47f, 0.20f, 1.0f), "Solid"),
                new Substance("H20", Color.white, "Liquid")
            },
            ["H2".GetHashCode() + "PbO".GetHashCode()] = new List<Substance>
            {
                new Substance("Pb", new Color(0.45f, 0.89f, 0.96f, 1.0f), "Solid"),
                new Substance("H20", Color.white, "Liquid")
            },
            ["Cl2".GetHashCode() + "S".GetHashCode()] = new List<Substance>
            {
                new Substance("SCl4", new Color(0.88f, 0.91f, 0.46f), "Solid"),
            },
            ["Cl2".GetHashCode() + "C".GetHashCode()] = new List<Substance>
            {
                new Substance("CCl4", Color.white, "Liquid"),
            },
            ["Cl2".GetHashCode() + "Cu".GetHashCode()] = new List<Substance>
            {
                new Substance("CuCl2", new Color(0.23f, 0.94f, 0.57f), "Solid"),
            },
            ["Cl2".GetHashCode() + "Fe".GetHashCode()] = new List<Substance>
            {
                new Substance("FeCl3", Color.black, "Solid"),
            },
        };
    }

    void Update()
    {
        
    }
}
