using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyController _enemyPrefab;
    [SerializeField] private int _enemyCount;
    [SerializeField] public Score _score;
    
    

    private ColorsProvider _colorsProvider;

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            var position = GetRandomPosition();
            InstantiateEnemy(position);
        }
    }

    private void InstantiateEnemy(Vector3 position)
    {
        var enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        var color = _colorsProvider.GetColor();
        enemy.Initialize(color);
        AddScore(color);
        
    }

    private static Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomZ = Random.Range(-10f, 10f);
        
        return new Vector3(randomX, 0f, randomZ);
    }
    
    private void AddScore(Color color)
    {
        if (color == Color.red)
            _score.EnemyAppeared.Invoke('r', '+');
        if (color == Color.yellow)
            _score.EnemyAppeared.Invoke('y', '+');
        if (color == Color.green)
            _score.EnemyAppeared.Invoke('g', '+');
    }
    
}
