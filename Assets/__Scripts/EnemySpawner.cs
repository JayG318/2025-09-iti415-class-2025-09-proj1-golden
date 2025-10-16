using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject enemyPrefab;
    public float spawnEverySeconds = 3f;
    public float spawnRadius = 15f;
    public Transform center;

    void Start()
    {
        Invoke(nameof(SpawnOnce), 1f);
    }

    void SpawnOnce()
    {
        if (enemyPrefab != null)
        {
            Vector3 c;
            if (center != null)
            {
                c = center.position;
            }
            else
            {
                c = Vector3.zero;
            }

            Vector3 pos = c + new Vector3(Random.Range(-spawnRadius, spawnRadius), 0.5f, Random.Range(-spawnRadius, spawnRadius));
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }

        Invoke(nameof(SpawnOnce), spawnEverySeconds);
    }
}
