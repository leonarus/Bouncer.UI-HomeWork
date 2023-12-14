using UnityEngine;

public class MapBuilder : MonoBehaviour
{
    [SerializeField] private ColorsProvider _colorsProvider;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private KeySpawner _keySpawner;

    private void Awake()
    {
        _enemySpawner.Initialize(_colorsProvider);
        _keySpawner.Initialize(_colorsProvider);
    }
}
