using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private Transform pathPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float timeBetweenEnemySpawns = 1f;
    [SerializeField] private float spawnTimeVariance = 0.5f;
    [SerializeField] private float minSpawnTime = 0.2f;

    public int GetEnemyCount() => enemyPrefabs.Count;

    public GameObject GetEnemyPrefab(int index) => enemyPrefabs[index];

    public float GetMoveSpeed() => moveSpeed;

    public Transform GetStartingWaypoint() => pathPrefab.GetChild(0);

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints  = new List<Transform>();

        foreach(Transform child in pathPrefab) 
        {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float getRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);   
    }
}
