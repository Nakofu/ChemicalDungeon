using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Substance
{
    public string AggrState;
    public Color Color;
    public string Formula;

    public Substance(string aggrState, Color color, string formula)
    {
        AggrState = aggrState;
        Color = color;
        Formula = formula;
    }
}
