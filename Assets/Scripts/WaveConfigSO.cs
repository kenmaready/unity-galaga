using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{

    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    float moveSpeed = K.Enemy.MoveSpeed;
    float spawnTime = K.Enemy.Spawn.TimeBetween;
    float spawnTimeVariance = K.Enemy.Spawn.TimeVariance;
    float minSpawnTime = K.Enemy.Spawn.TimeMinimum;

    public Transform GetStartingWaypoint() {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints() {
        List<Transform> waypoints = new List<Transform>();

        foreach (Transform waypoint in pathPrefab) {
            waypoints.Add(waypoint);
        }

        return waypoints;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public int GetEnemyCount() {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index) {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime() {
        float eta = Random.Range(-spawnTimeVariance, spawnTimeVariance);
        return Mathf.Max(spawnTime + eta, minSpawnTime);
    }

}
