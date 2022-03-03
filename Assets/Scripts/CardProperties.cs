using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardProperties
{
    public string name;
    public Color color;

    public CardProperties(string name, string hexColor)
    {
        this.name = name;
        
        if (ColorUtility.TryParseHtmlString(hexColor, out var color))
            this.color = color;
    }
}
