using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//place and delete the cubes
public static class ObjectPlacer
{

    static List<Transform> platforms;
    public static void PlaceObject(Vector3 position, Color color, Transform platform)
    {
        Transform newPlatform = GameObject.Instantiate(platform, position, Quaternion.identity);
        newPlatform.GetComponentInChildren<MeshRenderer>().material.color = color;
        if (platforms == null)
        {
            platforms = new List<Transform>();
        }
        platforms.Add(newPlatform);
    }

    public static void RemoveObject(Vector3 position, Color color)
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].position == position && platforms[i].GetComponentInChildren<MeshRenderer>().material.color == color)
            {
                GameObject.Destroy(platforms[i].gameObject);
                platforms.RemoveAt(i);
            }
        }
    }

    public static void reset()
    {
        if(platforms != null)
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                GameObject.Destroy(platforms[i].gameObject);
                platforms.RemoveAt(i);
            }
            platforms.Clear();
        }
            
    }
}
