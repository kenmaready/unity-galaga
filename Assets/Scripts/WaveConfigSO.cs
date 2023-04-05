using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{

    [SerializeField] Transform pathPrefab;
    float moveSpeed = K.Enemy.MoveSpeed;

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

}
