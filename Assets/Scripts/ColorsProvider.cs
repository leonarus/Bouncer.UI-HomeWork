using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class ColorsProvider
{
    private Color[] _colors = { Color.red, Color.yellow, Color.green };

    public Color GetColor()
    {
        var index = Random.Range(0, 3);
        return _colors[index];
    }
    
}