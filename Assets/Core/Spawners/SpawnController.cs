using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTomato : MonoBehaviour
{
    public GameObject spawnObject;

    
    void Start()
    {
        spawnObjects();
    }

    void OnCollisionExit(Collision collision)
    {
        DeleteTomatoesInCollider();
        spawnObjects();
    }

    public void spawnObjects()
    {
        Instantiate(spawnObject, transform.position, transform.rotation);
        
        Vector3 position2 = transform.position;
        position2.x -= 0.11f;
        Instantiate(spawnObject, position2, transform.rotation);
        
        Vector3 position3 = transform.position;
        position3.x -= 0.22f;
        Instantiate(spawnObject, position3, transform.rotation);
    }

    public void DeleteTomatoesInCollider()
    {
        BoxCollider collider = GetComponent<BoxCollider>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Spawnable");

        foreach (GameObject o in objects)
        {
            if (collider.bounds.Contains(o.transform.position))
            {
                Destroy(o);
            }
        }
    }
}
