using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour
{
    public Color gizmosColor = Color.red;
    public GameObject enemy;
    public float spawnRange = 2f;
    // public int enemyCount;

    void Awake()
    {
        // foreach (int _ in Enumerable.Range(0, enemyCount))
        //     SpawnEnemy();

        foreach (Transform child in transform)
            SpawnEnemy((child.position, child.rotation));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmosColor;
        foreach (Transform child in transform)
            Gizmos.DrawSphere(child.position, 0.5f);

    }

    void OnDrawGizmosSelected()
    {
        foreach (Transform child in transform)
            if (Physics.Raycast(child.position + new Vector3(0, 100, 0), new Vector3(0, -1, 0), out var hitinfo, float.MaxValue))
                child.position = hitinfo.point + new Vector3(0, 1, 0);
    }

    void SpawnEnemy((Vector3 position, Quaternion rotation)? spawn = null)
    {
        (Vector3 position, Quaternion rotation) GetRandomSpawnPoint()
        {
            int childCount = transform.childCount;
            int childIndex = Random.Range(0, childCount);
            var child = transform.GetChild(childIndex);
            return (child.position + new Vector3(x: Random.Range(-1, 1), y: 0, z: Random.Range(-1, 1)).normalized * spawnRange, child.rotation);
        }

        var (position, rotation) = spawn ?? GetRandomSpawnPoint();
        Instantiate(enemy, position, rotation);
    }
}
