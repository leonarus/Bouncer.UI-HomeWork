using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    
    private ColorsProvider _colorsProvider;
    private Material _material;
    private Color _color;

    private void Start()
    {
        GetRandomPosition();
        SetColor();
    }
    
    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        _material = _renderer.materials.First(material => material.name.Contains(GlobalConstants.COLOR_MATERIAL));
        _color = _material.color;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<ColoredObject>(out var coloredObject))
        {
            coloredObject.SetColor(_color);
            transform.position = GetRandomPosition();
            SetColor();
        }
    }

    private void SetColor()
    {
        var newColor = _colorsProvider.GetColor();
        _material.color = _color = newColor;
    }


    private static Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        
        return new Vector3(randomX, 0f, randomZ);
    }
}
