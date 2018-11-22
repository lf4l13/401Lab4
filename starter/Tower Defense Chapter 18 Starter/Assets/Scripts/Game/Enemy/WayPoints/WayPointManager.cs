using UnityEngine;
using System.Collections.Generic;

public class WayPointManager : MonoBehaviour
{
    // this allows easy access to a manager-type class from anywhere like a simplerversion of the singleton pattern
    public static WayPointManager Instance;
    // The list of stored paths 
    public List<Path> Paths = new List<Path>();

    void Awake()
    {
        // Sets value. This refers to WayPointManager the class it's writtne in 
        Instance = this;
    }

    // Returns enemies spawn positon which depends on the path they'll take, by taking index 0 
    public Vector3 GetSpawnPosition(int pathIndex)
    {
        return Paths[pathIndex].WayPoints[0].position;
    }

}

// This is where the path is defined and stored as transforms.
[System.Serializable]
public class Path
{
    public List<Transform> WayPoints = new List<Transform>();
}