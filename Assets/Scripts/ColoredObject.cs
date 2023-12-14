using System.Linq;
using UnityEngine;

public class ColoredObject : MonoBehaviour
{
    public Color Color { get; private set; }

    [SerializeField] private Renderer _renderer;
    private Material _material;

    private void Awake()
    {
        _material = _renderer.materials.First(material => material.name.Contains(GlobalConstants.COLOR_MATERIAL));
    }

    public void SetColor(Color color)
    {
        _material.color = Color = color;
    }
}
