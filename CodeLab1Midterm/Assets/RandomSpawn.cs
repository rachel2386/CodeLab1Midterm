using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> objectsToSpawn = new List<GameObject>();
    void Start()
    {
        if (objectsToSpawn.Count > 0)
        {
            Instantiate(objectsToSpawn[Random.Range(0, objectsToSpawn.Count)],transform.position,Quaternion.identity);
        }
    }

}
