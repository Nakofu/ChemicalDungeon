using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Substance
{
    public string AggrState;
    public Color Color;
    public string Formula;

    public Substance(string formula, Color color, string aggrState)
    {
        Formula = formula;
        Color = color;
        AggrState = aggrState;
    }
}
